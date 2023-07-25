using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views;
using VaccPet.MVVM.Views.Components;
using VaccPet.Services;

namespace VaccPet.MVVM.ViewModels
{
    public class ListPetViewModel : BaseViewModel
    {
        #region VARIABLES

        private readonly IPetService _IPetService;

        PopupViewModel PopupViewModel { get; set; } = new PopupViewModel();

        Popup PopupListActionsControl { get; set; }

        PetModel PetModelObject { get; set; }

        public ObservableCollection<PetModel> PetsCollection { get; set; }

        #endregion

        #region COMMANDS
        public ICommand AddPetCommand { get; set; }
        public ICommand SelectedPetInCollectionCommand { get; set; }
        public ICommand DeletePetCommand { get; set; }
        public ICommand DeleteAllPetCommand { get; set; }
        public ICommand EditPetCommand { get; set; }
        public ICommand DetailPetCommand { get; set; }
        public ICommand SearchEmptyCommand { get; set; }
        public ICommand GoToListVaccines { get; set; }

        
        #endregion

        #region PROPS

        ImageSource imageData;
        public ImageSource ImageData
        {
            get => imageData;
            set => SetProperty(ref imageData, value);
        }


        string textSearch;
        public string TextSearch
        {
            get => textSearch;
            set
            {
                textSearch = value;
                SetProperty(ref this.textSearch, value);

                if (textSearch.Length > 0)
                    OnSearchPetCommand();
                else
                    SearchEmptyCommand.Execute(null);
            }
        }


        #endregion

        public ListPetViewModel()
        {
        }

        public ListPetViewModel(IPetService IPetService)
        {
            _IPetService = IPetService;

            PetsCollection = new ObservableCollection<PetModel>();
            AddPetCommand = new Command(OnAddPetCommand);
            DeleteAllPetCommand = new Command(OnDeleteAllPetCommand);
            SelectedPetInCollectionCommand = new Command<PetModel>(OnSelectedPetInCollectionCommand);
            EditPetCommand = new Command(OnEditPetCommand);
            DeletePetCommand = new Command(OnDeletePetCommand);
            DetailPetCommand = new Command(OnDetailPetCommand);
            SearchEmptyCommand = new Command(async () => await LoadAllPets());
            GoToListVaccines = new Command(OnGoToListVaccines);
        }

       

        #region METHODS

        public async void OnSelectedPetInCollectionCommand(PetModel petSelected)
        {
            PetModelObject = petSelected;

            PopupListActionsControl = new PopupListActionsPage(
                    PopupViewModel.SetParametersPopup("Editar", "Excluir", "Detalhes", "Vacinas",
                                                       petSelected, EditPetCommand, DeletePetCommand, 
                                                       DetailPetCommand, GoToListVaccines));

            await App.Current.MainPage.ShowPopupAsync(PopupListActionsControl);
        }

        private async void OnDeletePetCommand()
        {
            var result = await App.Current.MainPage.DisplayAlert("Excluir", "Deseja realmente excluir este Pet da Lista?", "Sim", "Não");

            if (result)
            {
                PopupListActionsControl.Close();
                await _IPetService.DeletePet(PetModelObject);
                PetsCollection.Remove(PetModelObject);

                await App.Current.MainPage.ShowPopupAsync(new PopupSuccessConfirmationPage());
            }
            else
            {
                PopupListActionsControl.Close();
                return;
            }

        }

        private async void OnDeleteAllPetCommand()
        {
            if(PetsCollection.Count > 0)
            {
                var result = await App.Current.MainPage.DisplayAlert("Excluir", "Deseja realmente excluir todos Pets da Lista?", "Sim", "Não");

                if (result)
                {
                    await _IPetService.DeleteAllPets();
                    PetsCollection.Clear();
                    await App.Current.MainPage.ShowPopupAsync(new PopupSuccessConfirmationPage());
                }              
            }           
        }

        private async void OnEditPetCommand()
        {
            PopupListActionsControl.Close();

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "PetSelectedForEdit", PetModelObject }
            };

            await Navigation.NavigateToPageAsync<EditPetPage>(parameters);
        }

        private async void OnGoToListVaccines()
        {
            PopupListActionsControl.Close();

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "PetSelectedForVaccine", PetModelObject }
            };

            await Navigation.NavigateToPageAsync<ListVaccinePetPage>(parameters);
        }

        private async void OnDetailPetCommand()
        {
            PopupListActionsControl.Close();

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "DetailPetSelected", PetModelObject }
            };

            await Navigation.NavigateToPageAsync<DetailPetPage>(parameters);
        }

        private async void OnAddPetCommand()
        {
            await Navigation.NavigateToViewModelAsync<RegisterPetViewModel>(null);
        }

        private void OnSearchPetCommand()
        {
            var pets = PetsCollection.Where(x => x.Name.ToUpper()
                                      .Contains(TextSearch.ToUpper())).ToList();

            if (pets.Count > 0)
            {
                PetsCollection.Clear();

                foreach (var item in pets)
                {
                    PetsCollection.Add(item);
                }
            }
        }

        public async Task LoadAllPets()
        {
            IsBusy = true;

            var pets = await _IPetService.GetPetsList();


            PetsCollection.Clear();

            foreach (var pet in pets)
            {
                var age = AgeCalculator(pet.BirthDate);
                pet.Age = age;
                PetsCollection.Add(pet);
            }

            IsBusy = false;
        }

        public async void OnAppearing()
        {
            await LoadAllPets();
        }

        public static int AgeCalculator(DateTime data, DateTime? now = null)
        {
            now = ((now == null) ? DateTime.Now : now);

            try
            {
                int YearsOld = (now.Value.Year - data.Year);

                if (now.Value.Month < data.Month || (now.Value.Month == data.Month && now.Value.Day < data.Day))
                {
                    YearsOld--;
                }

                return (YearsOld < 0) ? 0 : YearsOld;
            }
            catch
            {
                return 0;
            }
        }
        
        #endregion
    }
}
