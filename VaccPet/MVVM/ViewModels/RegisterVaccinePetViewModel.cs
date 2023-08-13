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
      
        private readonly VaccineModelRepository _VaccineModelRepository;

        #endregion

        #region PROPS 

        private PetModel _registerVaccinePet;
        public PetModel RegisterVaccinePet
        {
            get => _registerVaccinePet;
            set => SetProperty(ref _registerVaccinePet, value);
        }


        private List<VaccineHelper> _vaccineList;
        public List<VaccineHelper> VaccineList
        {
            get => _vaccineList;
            set => SetProperty(ref _vaccineList, value);
        }


        private DateTime _vacinationDate = DateTime.Now;
        public DateTime VacinationDate
        {
            get => _vacinationDate;
            set => SetProperty(ref this._vacinationDate, value);
        }
        

        private DateTime _maxVacinationDate = DateTime.Now.AddYears(2);
        public DateTime MaxVacinationDate
        {
            get => _maxVacinationDate;
            set => SetProperty(ref this._maxVacinationDate, value);
        }


        private DateTime _minVacinationDate = DateTime.Now.AddYears(-1);
        public DateTime MinVacinationDate
        {
            get => _minVacinationDate;
            set => SetProperty(ref this._minVacinationDate, value);
        }


        private DateTime _revacinationDate = DateTime.Now;
        public DateTime RevacinationDate
        {
            get => _revacinationDate;
            set => SetProperty(ref this._revacinationDate, value);
        }

        private Color _revacinationColor =  Color.FromRgba("#D54A9E");
        public Color RevacinationColor
        {
            get => _revacinationColor;
            set => SetProperty(ref this._revacinationColor, value);
        }



        private DateTime _maxRevacinationDate = DateTime.Now.AddYears(2);
        public DateTime MaxRevacinationDate
        {
            get => _maxRevacinationDate;
            set => SetProperty(ref this._maxRevacinationDate, value);
        }


        private DateTime _minRevacinationDate = DateTime.Now;
        public DateTime MinRevacinationDate
        {
            get => _minRevacinationDate;
            set => SetProperty(ref this._minRevacinationDate, value);
        }


        private VaccineHelper _vaccineSelected;
        public VaccineHelper VaccineSelected
        {
            get => _vaccineSelected;
            set => SetProperty(ref this._vaccineSelected, value);
        }


        private string _vaccineName;
        public string VaccineName
        {
            get => _vaccineName;
            set => SetProperty(ref this._vaccineName, value);
        }


        private double _weightPet;
        public double WeightPet
        {
            get => _weightPet;
            set => SetProperty(ref this._weightPet, value);
        }


        private bool _isToggledAllOk;
        public bool IsToggledAllOk
        {
            get => _isToggledAllOk;
            set
            {
                SetProperty(ref _isToggledAllOk, value);
                if(IsToggledAllOk)
                    AllFieldsOk = true;
                else
                    AllFieldsOk = false;
            }
        }


        private bool _allFieldsOk;
        public bool AllFieldsOk
        {
            get => _allFieldsOk;
            set => SetProperty(ref _allFieldsOk, value);
        }

        #endregion

        #region COMMANDS

        public ICommand AddVaccinePetCommand { get; set; }

        #endregion  

        public RegisterVaccinePetViewModel()
        {            
            _VaccineModelRepository = new VaccineModelRepository(App.dbPath);

            AddVaccinePetCommand = new Command(OnAddVaccinePetCommand);
        }

        #region METHODS

        private async void OnAddVaccinePetCommand()
        {
            VaccineModel model = new VaccineModel();

            model.VaccinationDate = VacinationDate;
            model.RevaccinateDate = RevacinationDate;
            model.VaccineName = VaccineSelected.Value;
            model.Weight = WeightPet;
            model.PetlId = RegisterVaccinePet.Id;
           
            var result = await _VaccineModelRepository.SaveVaccineAsync(model);
          
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

        #endregion
    }
}
