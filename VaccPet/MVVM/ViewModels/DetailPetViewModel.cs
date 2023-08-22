using System.Windows.Input;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views;

namespace VaccPet.MVVM.ViewModels
{
    [QueryProperty(nameof(DetailPetSelected), "DetailPetSelected")]
    public class DetailPetViewModel : BaseViewModel
    {        
        #region PROPS

        string sexName;
        public string SexName
        {
            get => sexName;
            set => SetProperty(ref this.sexName, value);
        }


        private PetModel detailPetSelected;
        public PetModel DetailPetSelected
        {
            get => detailPetSelected;
            set
            {               
                SetProperty(ref this.detailPetSelected, value);
                if (DetailPetSelected.Sex == "F")
                {
                    SexIcon = "female";
                    SexName = "Fêmea";
                }
                else
                {
                    SexIcon = "male";
                    SexName = "Macho";
                }                   
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

        public DetailPetViewModel()
        {           
            EditPetDetailCommand = new Command(OnEditPetDetailCommand);
        }

        #region METHODS
        private async void OnEditPetDetailCommand(object obj)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"PetSelectedForEdit", DetailPetSelected}
            };

            await Navigation.NavigateToPageAsync<EditPetPage>(parameters);
        }
        #endregion
    }
}
