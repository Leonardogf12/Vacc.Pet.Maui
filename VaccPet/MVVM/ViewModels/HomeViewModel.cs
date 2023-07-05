using System.Collections.ObjectModel;
using System.Globalization;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views;
using VaccPet.Services;
using static System.Collections.Specialized.NameObjectCollectionBase;

namespace VaccPet.MVVM.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {        
        private readonly IPetService _IPetService;

        public ObservableCollection<PetModel> PetsCollection { get; set; }

        #region COMMANDS
        public Command AddPetCommand { get; set; }

        #endregion

        public HomeViewModel(IPetService IPetService)
        {
            _IPetService = IPetService;

            PetsCollection = new ObservableCollection<PetModel>();

            AddPetCommand = new Command(OnAddPetCommand);

        }

        async void OnAddPetCommand()
        {
            await Navigation.NavigateToAsync<ListPetViewModel>(null);
            //await App.Current.MainPage.Navigation.PushAsync(new RegisterPetPage(new RegisterPetViewModel(null)));
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

        public async void OnAppearing()
        {
            await OnLoadAllPets();            
        }

        
    }
}
