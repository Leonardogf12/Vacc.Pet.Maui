using Mopups.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views.Components;
using VaccPet.Services;
using static System.Collections.Specialized.NameObjectCollectionBase;

namespace VaccPet.MVVM.ViewModels
{
    public class ListPetViewModel : BaseViewModel
    {
        private readonly IPetService _IPetService;

        PopupViewModel popupViewModel { get; set; } = new PopupViewModel();

        PetModel PetModelObject { get; set; }

        public ObservableCollection<PetModel> PetsCollection { get; set; }


        #region COMMANDS
        public Command AddPetCommand { get; set; }
        public Command DeleteAllPetCommand { get; set; }        
        public Command SelectedPetInCollectionCommand { get; set; }

        public Command TestCommand { get; set; }

        public ICommand EditPetCommand { get; set; }
        public ICommand DeletePetCommand { get; set; }
        #endregion

        ImageSource imageData;
        public ImageSource ImageData
        {
            get => imageData;
            set => SetProperty(ref imageData, value);
        }

        public ListPetViewModel()
        {            
        }

        public ListPetViewModel(IPetService IPetService)
        {
            _IPetService = IPetService;          

            PetsCollection = new ObservableCollection<PetModel>();

            AddPetCommand = new Command(OnAddPetCommand);

            DeleteAllPetCommand = new Command(OnDeleteAllPetCommand);

            SelectedPetInCollectionCommand = new Command(OnSelectedPetInCollectionCommand);

            EditPetCommand = new Command(OnEditPetCommand);

            DeletePetCommand = new Command(OnDeletePetCommand);

            TestCommand = new Command<PetModel>(OnTestCommand);
        }

        private void OnTestCommand(PetModel obj)
        {
            PetModelObject = obj;

            MopupService.Instance.PushAsync(new PopupConfirmationPage(
                    popupViewModel.SetParametersPopup("Edit", "Excluir", obj, EditPetCommand, DeletePetCommand)), true);
        }

        private async void OnDeletePetCommand()
        {         
            var result = await App.Current.MainPage.DisplayAlert("Excluir", "Deseja realmente excluir este Pet da Lista?", "Sim", "Não");

            if (result)
            {
                await MopupService.Instance.PopAsync();
                await _IPetService.DeletePet(PetModelObject);                
                PetsCollection.Remove(PetModelObject);
                await App.Current.MainPage.DisplayAlert("Sucesso", "Pet excluído com sucesso.", "Fechar");                               
            }
            else
            {
                return;
            }
           
        }

        private async void OnEditPetCommand(object obj)
        {
            await MopupService.Instance.PopAsync();

            //TODO Navegar para Edição
            //await Navigation.NavigateToAsync<RegisterPetViewModel>(null);
        }

        public void OnSelectedPetInCollectionCommand()
        {
            try
            {
                MopupService.Instance.PushAsync(new PopupConfirmationPage(
                    popupViewModel.SetParametersPopup("Edit", "Excluir", EditPetCommand, DeletePetCommand)), true);
            }
            catch (Exception e)
            {
                throw;
            }
            
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
