using static VaccPet.Mokup.VaccineMokupHelper;

namespace VaccPet.MVVM.ViewModels
{
    public class ListVaccinePetViewModel : BaseViewModel
    {

        #region DATA MOKUP
        public readonly VaccineMokupData data;

        public IReadOnlyList<VaccineMokup> VaccinesCollection { get => data.VaccineMokupCollection; }
        #endregion

        public ListVaccinePetViewModel()
        {
            data = new VaccineMokupData();           
        }

    }
}
