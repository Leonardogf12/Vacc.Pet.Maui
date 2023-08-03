using System.Collections.ObjectModel;
using System.Windows.Input;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views;
using VaccPet.Repositories;
using static System.Collections.Specialized.NameObjectCollectionBase;
using static VaccPet.Mokup.VaccineMokupHelper;

namespace VaccPet.MVVM.ViewModels
{
    [QueryProperty(nameof(PetSelectedForVaccine), "PetSelectedForVaccine")]
    public class ListVaccinePetViewModel : BaseViewModel
    {

        #region VARIABLES

        private readonly VaccineModelRepository _VaccineModelRepository;
             
        #endregion

        #region PROPS

        PetModel petSelectedForVaccine;
        public PetModel PetSelectedForVaccine
        {
            get => petSelectedForVaccine;
            set
            {
                SetProperty(ref petSelectedForVaccine, value);
              
                GetAllVaccinesOfPetSelected();
            }
        }

        private ObservableCollection<VaccineModel> _vaccineModelCollection;
        public ObservableCollection<VaccineModel> VaccineModelCollection
        {
            get => _vaccineModelCollection;
            set => SetProperty(ref _vaccineModelCollection, value);
        }

        private int _vaccineCount;
        public int VaccineCount
        {
            get => _vaccineCount;
            set=> SetProperty(ref _vaccineCount, value);
        }

        #endregion

        #region COMMANDS

        public ICommand AddVaccinePetCommand { get; set; }

        #endregion

        public ListVaccinePetViewModel()
        {
            VaccineModelCollection = new ObservableCollection<VaccineModel>();

            _VaccineModelRepository = new VaccineModelRepository(App.dbPath);
          
            AddVaccinePetCommand = new Command(OnAddVaccinePetCommand);
            
        }

        private async void GetAllVaccinesOfPetSelected()
        {
            VaccineModelCollection = new ObservableCollection<VaccineModel>();

            var listVaccines = await _VaccineModelRepository.GetAllVaccinesByPetAsync(PetSelectedForVaccine.Id);
            
            VaccineModelCollection.Clear();

            foreach (var item in listVaccines)
            {
                VaccineModelCollection.Add(item);
            }

            VaccineCount = VaccineModelCollection.Count;
        }

        private async void OnAddVaccinePetCommand()
        {
            PetModel petModel = (PetModel)PetSelectedForVaccine;

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "RegisterVaccinePet", petModel },
            };

            await Navigation.NavigateToPageAsync<RegisterVaccinePetPage>(parameters);
        }
      
    }
}
