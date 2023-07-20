using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using VaccPet.Helpers.Image;
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
        private readonly IImageContainerHelper _IImageContainerHelper;

        public AnimalHelper _animalHelper { get; set; } = new AnimalHelper();
        #endregion

        #region PROPS

        PetModel petSelectedForEdit;
        public PetModel PetSelectedForEdit
        {
            get => petSelectedForEdit;
            set => SetProperty(ref this.petSelectedForEdit, value);
        }

        AnimalHelper animalSelected;
        public AnimalHelper AnimalSelected
        {
            get => animalSelected;
            set
            {
                SetProperty(ref animalSelected, value);

                if (animalSelected != null)
                    BreedsList = _IAnimalService.GetBreedsByAnimal(AnimalSelected.Value);
                else
                    App.Current.MainPage.DisplayAlert("Erro", $"Não foi possível carregar a lista " +
                        $"de raças de {AnimalSelected.Value}. Favor tentar novamente.", "Ok");
            }
        }

        AnimalHelper breedSelected;
        public AnimalHelper BreedSelected
        {
            get => breedSelected;
            set => SetProperty(ref breedSelected, value);
        }

        List<AnimalHelper> animalsList;
        public List<AnimalHelper> AnimalsList
        {
            get => animalsList;
            set => SetProperty(ref animalsList, value);
        }

        List<AnimalHelper> breedsList;
        public List<AnimalHelper> BreedsList
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

        bool imageVector = true;
        public bool ImageVector
        {
            get => imageVector;
            set => SetProperty(ref imageVector, value);
        }

        #endregion

        #region COMMANDS
        public ICommand UpdatePetCommand { get; set; }

        public ICommand GetImageFromGalleryCommand { get; set; }

        #endregion

        public EditPetViewModel(IPetService IPetService,
                                IAnimalService IAnimalService,
                                IImageContainerHelper IImageContainerHelper)
        {
            _IPetService = IPetService;
            _IAnimalService = IAnimalService;
            _IImageContainerHelper = IImageContainerHelper;

            UpdatePetCommand = new Command(OnUpdatePetCommand);
            GetImageFromGalleryCommand = new Command(async () => await OnGetImageFromGalleryCommand());
        }

        #region METHODS
        private async void OnUpdatePetCommand()
        {
            PetModel petModel = (PetModel)PetSelectedForEdit;

            if (ImagePath != "")
                petModel.ImageData = await _IImageContainerHelper.ReadImageBytes(ImagePath);

            var result = await _IPetService.UpdatePet(petModel);

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

        #endregion
    }
}
