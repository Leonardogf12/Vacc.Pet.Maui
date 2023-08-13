using System.Collections.ObjectModel;
using System.Windows.Input;
using VaccPet.Helpers.Models;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views;
using VaccPet.Services;
using VaccPet.Services.Navigation;

namespace VaccPet.MVVM.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region VARIABLES

        private readonly INavigationService _navigationService;
        public ObservableCollection<PetModel> PetsCollection { get; set; } = new();
        public ObservableCollection<HomeMenuHorizontalModel> HomeMenuHorizontalModelCollection { get; set; } = new();

        public HomeMenuHorizontalModel _homeMenuHorizontalModel = new();

        #endregion

        #region COMMANDS
        public ICommand ListPetsCommand { get; set; }

        public Command NavigationMenuHorizontalCommand { get; set; }      

        #endregion


        public HomeViewModel()
        {                                 
            ListPetsCommand = new Command(OnListPetsCommand);
            NavigationMenuHorizontalCommand = new Command<HomeMenuHorizontalModel>(OnNavigationMenuHorizontalCommand);

            BuildListMenuHorizontalHome();
        }

        private void BuildListMenuHorizontalHome()
        {          
            foreach (var item in _homeMenuHorizontalModel.GetListMenuHorizontalItems())
            {
                HomeMenuHorizontalModelCollection.Add(item);
            }           
        }

        #region METHODS
        async void OnListPetsCommand()
        {
            await Navigation.NavigateToViewModelAsync<ListPetViewModel>(null);
        }

        #endregion

       
        private async void OnNavigationMenuHorizontalCommand(HomeMenuHorizontalModel model)
        {
            //TODO Create Navigation or action from future pages.
        }       

    }
}
