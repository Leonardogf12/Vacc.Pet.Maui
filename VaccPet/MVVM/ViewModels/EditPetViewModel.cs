using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using VaccPet.Helpers.Models;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views.Components;
using VaccPet.Services;

namespace VaccPet.MVVM.ViewModels
{
    [QueryProperty(nameof(PetSelectedForEdit), "PetSelectedForEdit")]
    public class EditPetViewModel : BaseViewModel
    {
        #region VARIABLES
        private readonly IPetService _IPetService;
        private readonly IAnimalService _IAnimalService;

        public Animal AnimalHelper { get; set; } = new Animal();
        #endregion

        #region PROPS

        PetModel petSelectedForEdit;
        public PetModel PetSelectedForEdit
        {
            get => petSelectedForEdit;
            set => SetProperty(ref this.petSelectedForEdit, value);
        }

        Animal animalSelected;
        public Animal AnimalSelected
        {
            get => animalSelected;
            set
            {
                SetProperty(ref animalSelected, value);
                GetBreedsByAnimal();
            }
        }

        Animal breedSelected;
        public Animal BreedSelected
        {
            get => breedSelected;
            set => SetProperty(ref breedSelected, value);
        }

        List<Animal> animalsList;
        public List<Animal> AnimalsList
        {
            get => animalsList;
            set => SetProperty(ref animalsList, value);
        }

        List<Animal> breedsList;
        public List<Animal> BreedsList
        {
            get => breedsList;
            set => SetProperty(ref breedsList, value);
        }

        string _imagePath;
        public string ImagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }
        #endregion

        #region COMMANDS
        public ICommand UpdatePetCommand { get; set; }

        public ICommand GetImageFromGalleryCommand { get; set; }

        #endregion

        public EditPetViewModel(IPetService IPetService, 
                                IAnimalService IAnimalService)
        {
            _IPetService = IPetService;
            _IAnimalService = IAnimalService;

            UpdatePetCommand = new Command(OnUpdatePetCommand);
            GetImageFromGalleryCommand = new Command(OnGetImageFromGalleryCommand);
        }

        #region METHODS
        private async void OnUpdatePetCommand()
        {
            PetModel petModel = (PetModel)PetSelectedForEdit;

            petModel.ImageData = ImagePath == null ? await GetImageDefault(AnimalSelected.Value) : await ReadImageBytes(ImagePath);

            var result = await _IPetService.UpdatePet(petModel);

            if (result > 0)
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

        private void GetBreedsByAnimal()
        {
            if (AnimalSelected.Value == "Cachorro")
            {
                BreedsList = AnimalHelper.GetBreedDogs();
            }
            else if (AnimalSelected.Value == "Gato")
            {
                BreedsList = AnimalHelper.GetBreedCats();
            }
            else if (AnimalSelected.Value == "Ave")
            {
                BreedsList = AnimalHelper.GetBreedBirds();
            }
            else
            {
                BreedsList = new List<Animal> { new Animal { Key = 1000, Value = "Não Definida" } };
            }
        }

        public async void OnGetImageFromGalleryCommand()
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync();

                if (result != null)
                    ImagePath = result.FullPath;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}
