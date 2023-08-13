using System.Collections.ObjectModel;
using System.Windows.Input;
using VaccPet.Helpers.Models;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views;
using VaccPet.Services.Navigation;

namespace VaccPet.MVVM.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region VARIABLES

        private readonly INavigationService _navigationService;

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
            //TODO Create Navigation or action from future pages.

            switch (model.Id)
            {
                case 1:
                    await App.Current.MainPage.Navigation.PushAsync(new CardTopAHomePage());
                    break;
                case 2:
                    await App.Current.MainPage.Navigation.PushAsync(new CardTopBHomePage());
                    break;
                case 3:
                    await App.Current.MainPage.Navigation.PushAsync(new CardTopCHomePage());
                    break;
                case 4:
                    await App.Current.MainPage.Navigation.PushAsync(new CardMiddleAHomePage());
                    break;
                case 5:
                    await App.Current.MainPage.Navigation.PushAsync(new CardMiddleBHomePage());
                    break;
            }
        }


        #endregion

    }
}
