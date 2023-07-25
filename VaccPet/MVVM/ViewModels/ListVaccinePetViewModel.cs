using System.Windows.Input;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views;
using static VaccPet.Mokup.VaccineMokupHelper;

namespace VaccPet.MVVM.ViewModels
{
    [QueryProperty(nameof(PetSelectedForVaccine),"PetSelectedForVaccine")]
    public class ListVaccinePetViewModel : BaseViewModel
    {

        #region DATA MOKUP
        public readonly VaccineMokupData data;

        public IReadOnlyList<VaccineMokup> VaccinesCollection { get => data.VaccineMokupCollection; }
        #endregion


        #region PROPS

        PetModel petSelectedForVaccine;
        public PetModel PetSelectedForVaccine
        {
            get => petSelectedForVaccine;
            set=> SetProperty(ref petSelectedForVaccine, value);
        }


        #endregion

        #region COMMANDS

        public ICommand AddVaccinePetCommand { get; set; }

        #endregion

        public ListVaccinePetViewModel()
        {
            data = new VaccineMokupData();

            AddVaccinePetCommand = new Command(OnAddVaccinePetCommand);
        }

        private async void OnAddVaccinePetCommand()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "RegisterVaccinePet", PetSelectedForVaccine },
            };

            await Navigation.NavigateToPageAsync<RegisterVaccinePetPage>(parameters);
        }
    }
}
