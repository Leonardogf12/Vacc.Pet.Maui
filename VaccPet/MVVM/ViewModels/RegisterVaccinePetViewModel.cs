using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using VaccPet.Helpers.Models;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views.Components;
using VaccPet.Repositories;
using VaccPet.Services;

namespace VaccPet.MVVM.ViewModels
{
    [QueryProperty(nameof(RegisterVaccinePet), "RegisterVaccinePet")]
    public class RegisterVaccinePetViewModel : BaseViewModel
    {

        #region VARIABLES

        private readonly IVaccineService _IVaccineService;

        private readonly VaccineModelRepository _VaccineModelRepository;


        #endregion

        #region PROPS 

        private PetModel registerVaccinePet;
        public PetModel RegisterVaccinePet
        {
            get => registerVaccinePet;
            set => SetProperty(ref this.registerVaccinePet, value);
        }

        List<VaccineHelper> vaccineList;
        public List<VaccineHelper> VaccineList
        {
            get => vaccineList;
            set => SetProperty(ref vaccineList, value);
        }

        DateTime vacinationDate;
        public DateTime VacinationDate
        {
            get => vacinationDate;
            set => SetProperty(ref this.vacinationDate, value);
        }

        DateTime revacinationDate;
        public DateTime RevacinationDate
        {
            get => revacinationDate;
            set => SetProperty(ref this.revacinationDate, value);
        }

        VaccineHelper vaccineSelected;
        public VaccineHelper VaccineSelected
        {
            get => vaccineSelected;
            set => SetProperty(ref this.vaccineSelected, value);
        }

        string vaccineName;
        public string VaccineName
        {
            get => vaccineName;
            set => SetProperty(ref this.vaccineName, value);
        }

        double weightPet;
        public double WeightPet
        {
            get => weightPet;
            set => SetProperty(ref this.weightPet, value);
        }

        bool isToggledAllOk;
        public bool IsToggledAllOk
        {
            get => isToggledAllOk;
            set
            {
                SetProperty(ref isToggledAllOk, value);
                if(IsToggledAllOk)
                    AllFieldsOk = true;
                else
                    AllFieldsOk = false;
            }
        }

        bool allFieldsOk;
        public bool AllFieldsOk
        {
            get => allFieldsOk;
            set => SetProperty(ref allFieldsOk, value);
        }

        #endregion

        #region COMMANDS

        public ICommand AddVaccinePetCommand { get; set; }

        #endregion  

        public RegisterVaccinePetViewModel(IVaccineService IVaccineService)
        {
            _IVaccineService = IVaccineService;
            _VaccineModelRepository = new VaccineModelRepository(App.dbPath);

            AddVaccinePetCommand = new Command(OnAddVaccinePetCommand);
        }

        private async void OnAddVaccinePetCommand()
        {
            VaccineModel model = new VaccineModel();

            model.VaccinationDate = VacinationDate;
            model.RevaccinateDate = RevacinationDate;
            model.VaccineName = VaccineSelected.Value;
            model.Weight = WeightPet;
            model.PetlId = RegisterVaccinePet.Id;          

            var result = await _VaccineModelRepository.SaveVaccineAsync(model);
            //var result  = await _IVaccineService.AddVaccine(model);

            if(result > 0)
            {
                await App.Current.MainPage.ShowPopupAsync(new PopupSuccessConfirmationPage());
                return;
            }
            else
            {
                await App.Current.MainPage.ShowPopupAsync(new PopupErrorConfirmationPage());
                return;
            }
        }
    }
}
