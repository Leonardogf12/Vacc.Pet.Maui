using VaccPet.MVVM.Models;

namespace VaccPet.MVVM.ViewModels
{
    [QueryProperty(nameof(RegisterVaccinePet), "RegisterVaccinePet")]
    public   class RegisterVaccinePetViewModel : BaseViewModel
    {

        #region VARIABLES



        #endregion

        #region PROPS 

        PetModel registerVaccinePet;
        public PetModel RegisterVaccinePet
        {
            get => registerVaccinePet;
            set => SetProperty(ref registerVaccinePet, value);
        }

        #endregion

        public RegisterVaccinePetViewModel()
        {            
        }
    }
}
