using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using VaccPet.Helpers.Models;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views.Components;
using VaccPet.Repositories;

namespace VaccPet.MVVM.ViewModels
{
    [QueryProperty(nameof(RegisterVaccinePet), "RegisterVaccinePet")]
    [QueryProperty(nameof(RegisterRevaccinationVaccinePet), "RegisterRevaccinationVaccinePet")]
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


        private PetModel _registerRevaccinationVaccinePet;
        public PetModel RegisterRevaccinationVaccinePet
        {
            get => _registerRevaccinationVaccinePet;
            set => SetProperty(ref _registerRevaccinationVaccinePet, value);
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
            set
            {
                SetProperty(ref _vacinationDate, value);
                VacinationDateCard = VacinationDate.ToString("dd/MM/yyyy");
            }
        }


        private DateTime _maxVacinationDate = DateTime.Now.AddYears(2);
        public DateTime MaxVacinationDate
        {
            get => _maxVacinationDate;
            set => SetProperty(ref this._maxVacinationDate, value);
        }


        private DateTime _minVacinationDate = DateTime.Now.AddMonths(-1);
        public DateTime MinVacinationDate
        {
            get => _minVacinationDate;
            set => SetProperty(ref this._minVacinationDate, value);
        }


        private DateTime _revacinationDate = DateTime.Now.AddYears(1);
        public DateTime RevacinationDate
        {
            get => _revacinationDate;
            set
            {
                SetProperty(ref this._revacinationDate, value);
                RevacinationDateCard = RevacinationDate.ToString("dd/MM/yyyy");
            }
        }


        private Color _revacinationColor = Color.FromRgba("#D54A9E");
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
            set
            {
                SetProperty(ref this._vaccineSelected, value);
                VaccineSelectedCard = VaccineSelected.Value.ToString();
            }
        }


        private double _weightPet;
        public double WeightPet
        {
            get => _weightPet;
            set
            {
                SetProperty(ref this._weightPet, value);
                WeightPetCard = value.ToString();
            }
        }


        private string _observation;
        public string Observation
        {
            get => _observation;
            set => SetProperty(ref this._observation, value);
        }


        private bool _isToggledAllOk;
        public bool IsToggledAllOk
        {
            get => _isToggledAllOk;
            set
            {
                SetProperty(ref _isToggledAllOk, value);
                if (IsToggledAllOk)
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


        private string _vacinationDateCard;
        public string VacinationDateCard
        {
            get => _vacinationDateCard;
            set
            {
                _vacinationDateCard = value;
                SetProperty(ref _vacinationDateCard, value);
            }
        }


        private string _revacinationDateCard;
        public string RevacinationDateCard
        {
            get => _revacinationDateCard;
            set
            {
                _revacinationDateCard = value;
                SetProperty(ref _revacinationDateCard, value);
            }
        }


        private string _weightPetCard;
        public string WeightPetCard
        {
            get => _weightPetCard;
            set
            {
                _weightPetCard = value;
                SetProperty(ref _weightPetCard, value);
            }
        }


        private string _vaccineSelectedCard;
        public string VaccineSelectedCard
        {
            get => _vaccineSelectedCard;
            set => SetProperty(ref this._vaccineSelectedCard, value);
        }


        private Color _colorCycleStatus = Colors.DeepPink;
        public Color ColorCycleStatus
        {
            get => _colorCycleStatus;
            set
            {
                _colorCycleStatus = value;
                SetProperty(ref this._colorCycleStatus, value);
            }
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
            VaccineModel model = new VaccineModel
            {
                VaccinationDate = VacinationDate,
                RevaccinateDate = RevacinationDate,
                VaccineName = VaccineSelected.Value,
                Weight = WeightPet,
                PetlId = RegisterVaccinePet.Id,
                Observation = Observation,
                //model.CycleStatus = CycleStatus.Pendente.ToString()
            };

            var verifyOne = await CheckIfThereIsVaccineWithDateAndNameAlreadyRegistered(model);
            if (verifyOne)
            {
                await App.Current.MainPage.DisplayAlert("Ops", $"Já existe uma vacina do tipo {VaccineSelected.Value} " +
                    $"registrada para o dia {VacinationDate.ToShortDateString()}. Favor verificar.", "Ok");
                
                IsToggledAllOk = !verifyOne;
                
                return;
            }

            //var verifyTwo = await CheckCycleStatusForRegister(model);                        
            //if (verifyTwo != null){

            //    verifyTwo.CycleStatus = CycleStatus.Completo.ToString();

            //    await _VaccineModelRepository.UpdateVaccineAsync(verifyTwo);               
            //}           

            var result = await _VaccineModelRepository.SaveVaccineAsync(model);

            if (result > 0)
                await App.Current.MainPage.ShowPopupAsync(new PopupSuccessConfirmationPage());
            else
                await App.Current.MainPage.ShowPopupAsync(new PopupErrorConfirmationPage());

            return;
        }

        private async Task<VaccineModel> CheckCycleStatusForRegister(VaccineModel model)
        {
            var resut = await _VaccineModelRepository.GetAllVaccinesByPetAsync(model.PetlId);

            if (resut.Count <= 0) return null;

            var exist = resut.Where(x => x.RevaccinateDate.Date == model.VaccinationDate.Date && x.VaccineName == model.VaccineName).FirstOrDefault();

            if (exist != null) return exist;

            return null;
        }

        private async Task<bool> CheckIfThereIsVaccineWithDateAndNameAlreadyRegistered(VaccineModel model)
        {
            var resut = await _VaccineModelRepository.GetAllVaccinesByPetAsync(model.PetlId);

            if (resut.Count <= 0) return false;

            var exist = resut.Where(x => x.VaccinationDate == model.VaccinationDate && x.VaccineName == model.VaccineName).FirstOrDefault();

            if (exist != null)
                return true;

            return false;
        }

        public void ResetFields()
        {
            IsToggledAllOk = false;
            VacinationDate = DateTime.Now;
            RevacinationDate = DateTime.Now.AddYears(1);
            WeightPet = 0;

            VacinationDateCard = string.Empty;
            RevacinationDateCard = string.Empty;
            WeightPetCard = string.Empty;
            VaccineSelectedCard = string.Empty;
        }

        #endregion


    }
}
