using System.Text.RegularExpressions;
using VaccPet.MVVM.Models;

namespace VaccPet.MVVM.ViewModels
{
    [QueryProperty(nameof(DetailPetSelected), "DetailPetSelected")]
    public class DetailPetViewModel : BaseViewModel
    {

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


        public DetailPetViewModel()
        {
        }


    }
}
