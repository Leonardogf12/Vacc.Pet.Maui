using System.Collections.ObjectModel;
using System.Windows.Input;
using VaccPet.MVVM.Models;
using VaccPet.Services;

namespace VaccPet.MVVM.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region VARIABLES

        private readonly IPetService _IPetService;

        public ObservableCollection<PetModel> PetsCollection { get; set; }
        #endregion

        #region COMMANDS
        public ICommand ListPetsCommand { get; set; }

        #endregion

        public HomeViewModel(IPetService IPetService)
        {
            _IPetService = IPetService;

            PetsCollection = new ObservableCollection<PetModel>();

            ListPetsCommand = new Command(OnListPetsCommand);
        }

        #region METHODS
        async void OnListPetsCommand()
        {
            await Navigation.NavigateToAsync<ListPetViewModel>(null);          
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
        #endregion

    }
}
