using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using VaccPet.Helpers.Image;
using VaccPet.Helpers.Models;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views.Components;
using VaccPet.Repositories;
using VaccPet.Services;

namespace VaccPet.MVVM.ViewModels
{
    [QueryProperty(nameof(PetSelectedForEdit), "PetSelectedForEdit")]
    public class EditPetViewModel : BaseViewModel
    {
        #region VARIABLES

        private readonly IPetService _IPetService;
        private readonly IAnimalService _IAnimalService;
        private readonly IImageContainerHelper _IImageContainerHelper;

        private readonly PetModelRepository _PetModelRepository;

        public AnimalHelper _animalHelper { get; set; } = new AnimalHelper();
        #endregion

        #region PROPS

        private PetModel petSelectedForEdit;
        public PetModel PetSelectedForEdit
        {
            get => petSelectedForEdit;
            set => SetProperty(ref petSelectedForEdit, value);
        }


        private List<AnimalHelper> animalsList;
        public List<AnimalHelper> AnimalsList
        {
            get => animalsList;
            set => SetProperty(ref animalsList, value);
        }


        private AnimalHelper animalSelected;
        public AnimalHelper AnimalSelected
        {
            get => animalSelected;
            set => SetProperty(ref this.animalSelected, value);
        }


        List<AnimalHelper> breedsList;
        public List<AnimalHelper> BreedsList
        {
            get => breedsList;
            set => SetProperty(ref breedsList, value);
        }


        AnimalHelper breedSelected;
        public AnimalHelper BreedSelected
        {
            get => breedSelected;
            set => SetProperty(ref breedSelected, value);
        }


        string _imagePath;
        public string ImagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }


        bool imageVector = true;
        public bool ImageVector
        {
            get => imageVector;
            set => SetProperty(ref imageVector, value);
        }


        bool isToggledSex = false;
        public bool IsToggledSex
        {
            get => isToggledSex;
            set
            {
                SetProperty(ref isToggledSex, value);
                IsSexText = IsToggledSex ? "Macho" : "Fêmea";
            }
        }


        string isCastratedText = "Não";
        public string IsCastratedText
        {
            get => isCastratedText;
            set => SetProperty(ref isCastratedText, value);
        }


        string isSexText = "Fêmea";
        public string IsSexText
        {
            get => isSexText;
            set => SetProperty(ref isSexText, value);

        }


        bool isToggledCatrated = false;
        public bool IsToggledCatrated
        {
            get => isToggledCatrated;
            set
            {
                SetProperty(ref isToggledCatrated, value);

                IsCastratedText = IsToggledCatrated ? "Sim" : "Não";
            }
        }

        #endregion

        #region COMMANDS
        public ICommand UpdatePetCommand { get; set; }

        public ICommand GetImageFromGalleryCommand { get; set; }

        public ICommand SetDetailsPetCommand { get; set; }

        #endregion

        public EditPetViewModel(IPetService IPetService,
                                IAnimalService IAnimalService,
                                IImageContainerHelper IImageContainerHelper)
        {
            _IPetService = IPetService;
            _PetModelRepository = new PetModelRepository(App.dbPath);
            _IAnimalService = IAnimalService;
            _IImageContainerHelper = IImageContainerHelper;

            ImagePath = "image_vetor.svg";
            UpdatePetCommand = new Command(OnUpdatePetCommand);
            SetDetailsPetCommand = new Command(OnSetDetailsPetCommand);
            GetImageFromGalleryCommand = new Command(async () => await OnGetImageFromGalleryCommand());
        }

        #region METHODS
        private async void OnUpdatePetCommand()
        {
            PetModel petModel = (PetModel)PetSelectedForEdit;

            if (ImagePath != "" && ImagePath != "image_vetor.svg")
                petModel.ImageData = await _IImageContainerHelper.ReadImageBytes(ImagePath);

            //if (ImagePath != "" && ImagePath != "image_vetor.svg")
            //   petModel.ImageData = ImagePath;


            petModel.Sex = IsToggledSex ? "M" : "F";

            petModel.Catrated = IsToggledCatrated ? true : false;

            petModel.Animal = (AnimalSelected.Value != petModel.Animal) ? AnimalSelected.Value : petModel.Animal;

            var result = await _PetModelRepository.UpdatePetAsync(petModel);

            //var result = await _IPetService.UpdatePet(petModel);
            

            if (result > 0)
            {
                await App.Current.MainPage.ShowPopupAsync(new PopupSuccessConfirmationPage());
                await Navigation.GoBackAsync("..");
                return;
            }
            else
            {
                await App.Current.MainPage.ShowPopupAsync(new PopupErrorConfirmationPage());
                return;
            }

        }

        public async Task OnGetImageFromGalleryCommand()
        {
            var result = await ImageMediaPicker.GetImageFromGallery();

            if (result != null)
            {
                ImagePath = result;
                ImageVector = false;
            }
            else
            {
                ImageVector = true;
            }
        }

        public void OnSetDetailsPetCommand()
        {
            PetModel petModel = (PetModel)PetSelectedForEdit;

            var selectedAnimal = PetSelectedForEdit.Animal;

            ImagePath = "image_vetor.svg";

            if (petModel.Sex == "M")
            {
                IsToggledSex = true;
                IsSexText = "Macho";
            }
            else
            {
                IsToggledSex = false;
                IsSexText = "Fêmea";
            }

            if (petModel.Catrated)
            {
                IsCastratedText = "Sim";
                IsToggledCatrated = true;
            }
            else
            {
                IsToggledCatrated = false;
                IsCastratedText = "Não";
            }

            AnimalsList = _animalHelper.GetAllAnimals();

            AnimalSelected = AnimalsList.Where(x => x.Value == selectedAnimal).FirstOrDefault();
            AnimalSelected.Value = selectedAnimal;
            OnPropertyChanged(nameof(AnimalSelected));
        }

        #endregion
    }
}
