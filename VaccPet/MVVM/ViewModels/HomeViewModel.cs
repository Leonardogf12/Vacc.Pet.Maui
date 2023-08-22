using System.Collections.ObjectModel;
using System.Windows.Input;
using VaccPet.Helpers.Models;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views;

namespace VaccPet.MVVM.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region VARIABLES
        
        public ObservableCollection<PetModel> PetsCollection { get; set; } = new();

        public ObservableCollection<HomeMenuCardsHorizontalModel> HomeTopMenuHorizontalModelCollection { get; set; } = new();

        public ObservableCollection<HomeMenuCardsHorizontalModel> HomeMiddleMenuHorizontalModelCollection { get; set; } = new();


        public HomeMenuCardsHorizontalModel _homeMenuHorizontalModel = new();

        #endregion

        #region COMMANDS
        public ICommand ListPetsCommand { get; set; }

        public Command NavigationMenuHorizontalCommand { get; set; }

        #endregion


        public HomeViewModel()
        {          
            ListPetsCommand = new Command(OnListPetsCommand);
            NavigationMenuHorizontalCommand = new Command<HomeMenuCardsHorizontalModel>(OnNavigationMenuHorizontalCommand);

            BuildListMenuHorizontalHome();
        }


        #region METHODS

        async void OnListPetsCommand()
        {
            await Navigation.NavigateToViewModelAsync<ListPetViewModel>(null);
        }

        private async void BuildListMenuHorizontalHome()
        {
            foreach (var item in await _homeMenuHorizontalModel.GetListTopMenuCardsHorizontal()) HomeTopMenuHorizontalModelCollection.Add(item);

            foreach (var item in _homeMenuHorizontalModel.GetListMiddleMenuCardsHorizontal()) HomeMiddleMenuHorizontalModelCollection.Add(item);
        }

        private async void OnNavigationMenuHorizontalCommand(HomeMenuCardsHorizontalModel model)
        {           
            switch (model.Id)
            {
                case 1:
                    await Navigation.NavigateToPageAsync<CardTopAHomePage>(null);                    
                    break;
                case 2:
                    await Navigation.NavigateToPageAsync<CardTopBHomePage>(null);                   
                    break;
                case 3:
                    await Navigation.NavigateToPageAsync<CardTopCHomePage>(null);
                    break;                    
                case 4:
                    await Navigation.NavigateToPageAsync<CardMiddleAHomePage>(null);                 
                    break;
                case 5:
                    await Navigation.NavigateToPageAsync<CardMiddleBHomePage>(null);                   
                    break;
            }
        }


        #endregion

    }
}
