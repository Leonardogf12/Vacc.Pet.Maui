using System.Text.RegularExpressions;
using System.Windows.Input;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views;
using VaccPet.Services;

namespace VaccPet.MVVM.ViewModels
{
    [QueryProperty(nameof(DetailPetSelected), "DetailPetSelected")]
    public class DetailPetViewModel : BaseViewModel
    {
        #region VARIABLES

        private readonly IPetService _IPetService;

        #endregion

        #region PROPS

        private PetModel detailPetSelected;
        public PetModel DetailPetSelected
        {
            get => detailPetSelected;
            set
            {               
                SetProperty(ref this.detailPetSelected, value);
                if (DetailPetSelected.Sex == "F")
                    SexIcon = "female";
                else
                    SexIcon = "male";

            }
        }

        private string sexIcon ="";
        public string SexIcon
        {
            get => sexIcon;
            set => SetProperty(ref this.sexIcon, value);
        }

        #endregion

        #region COMMANDS

        public ICommand EditPetDetailCommand { get; set; }

        #endregion

        public DetailPetViewModel(IPetService IPetService)
        {
            _IPetService = IPetService;

            EditPetDetailCommand = new Command(OnEditPetDetailCommand);
        }

        private async void OnEditPetDetailCommand(object obj)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"PetSelectedForEdit", DetailPetSelected}
            };

            await Navigation.NavigateToPageAsync<EditPetPage>(parameters);
        }
    }
}
