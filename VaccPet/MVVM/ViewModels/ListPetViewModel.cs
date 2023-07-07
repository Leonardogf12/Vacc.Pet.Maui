using Mopups.Services;
using System.Collections.ObjectModel;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views.Components;
using VaccPet.Services;
using static System.Collections.Specialized.NameObjectCollectionBase;

namespace VaccPet.MVVM.ViewModels
{
    public class ListPetViewModel : BaseViewModel
    {
        private readonly IPetService _IPetService;

        public ObservableCollection<PetModel> PetsCollection { get; set; }


        #region COMMANDS
        public Command AddPetCommand { get; set; }
        public Command DeleteAllPetCommand { get; set; }

        //
        public Command SelectedPetInCollectionCommand { get; set; }


        #endregion

        ImageSource imageData;
        public ImageSource ImageData
        {
            get => imageData;
            set => SetProperty(ref imageData, value);
        }


        public ListPetViewModel(IPetService IPetService)
        {
            _IPetService = IPetService;

            PetsCollection = new ObservableCollection<PetModel>();

            AddPetCommand = new Command(OnAddPetCommand);

            DeleteAllPetCommand = new Command(OnDeleteAllPetCommand);

            SelectedPetInCollectionCommand = new Command(OnSelectedPetInCollectionCommand);
        }

        private void OnSelectedPetInCollectionCommand()
        {
            MopupService.Instance.PushAsync(new PopupConfirmationPage(), true);
        }

        private async void OnDeleteAllPetCommand()
        {
            var result = await App.Current.MainPage.DisplayAlert("Excluir", "Deseja realmente excluir todos Pets da Lista?", "Sim", "Não");

            if (result)
            {
                await _IPetService.DeleteAllPets();
                PetsCollection.Clear();
                await App.Current.MainPage.DisplayAlert("Sucesso", "Todos os items foram excluídos.", "Fechar");
            }
            else
            {
                return;
            }
        }

        private async void OnAddPetCommand()
        {
            await Navigation.NavigateToAsync<RegisterPetViewModel>(null);
        }

        public async Task OnLoadAllPets()
        {
            IsBusy = true;

            var pets = await _IPetService.GetPetsList();


            PetsCollection.Clear();

            foreach (var pet in pets)
            {
                PetsCollection.Add(pet);
            }

            IsBusy = false;
        }

        private ImageSource LoadImageFromByte(byte[] image)
        {
            return ImageSource.FromStream(() => new MemoryStream(image));
        }

        public async void OnAppearing()
        {
            await OnLoadAllPets();
        }
    }
}
