using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Windows.Input;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views;
using VaccPet.Repositories;
using static VaccPet.Mokup.VaccineMokupHelper;

namespace VaccPet.MVVM.ViewModels
{
    [QueryProperty(nameof(PetSelectedForVaccine), "PetSelectedForVaccine")]
    public class ListVaccinePetViewModel : BaseViewModel
    {

        #region DATA MOKUP
        public readonly VaccineMokupData data;

        public IReadOnlyList<VaccineMokup> VaccinesCollection { get => data.VaccineMokupCollection; }


        #endregion

        #region VARIABLES

        private readonly VaccineModelRepository _VaccineModelRepository;


        public ObservableCollection<VaccineModel> VaccineModelCollection { get; set; }       

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


        #endregion

        #region COMMANDS

        public ICommand AddVaccinePetCommand { get; set; }

        #endregion

        public ListVaccinePetViewModel()
        {
            _VaccineModelRepository = new VaccineModelRepository(App.dbPath);
            //data = new VaccineMokupData();

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
