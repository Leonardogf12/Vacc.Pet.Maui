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
    public class RegisterPetViewModel : BaseViewModel
    {
        #region VARIABLES

        private readonly IAnimalService _IAnimalService;

        private readonly IImageContainerHelper _ImageContainerHelper;

        private readonly PetModelRepository _PetModelRepository;

        public AnimalHelper _animalHelper { get; set; } = new AnimalHelper();

        #endregion

        #region PROPS

        string name = "";
        public string Name
        {
            get => name;
            set => SetProperty(ref this.name, value);
        }


        string color;
        public string Color
        {
            get => color;
            set => SetProperty(ref this.color, value);
        }


        DateTime birthDate;
        public DateTime BirthDate
        {
            get => birthDate;
            set => SetProperty(ref this.birthDate, value);
        }


        double weight = 0;
        public double Weight
        {
            get => weight;
            set => SetProperty(ref this.weight, value);
        }


        string _observation;
        public string Observation
        {
            get => _observation;
            set => SetProperty(ref this._observation, value);
        }


        bool isCatrated;
        public bool IsCatrated
        {
            get => isCatrated;
            set
            {
                SetProperty(ref this.isCatrated, value);

                if (IsCatrated)
                    IsCastratedText = "Sim";
                else
                    IsCastratedText = "Não";
            }
        }


        AnimalHelper animalSelected;
        public AnimalHelper AnimalSelected
        {
            get => animalSelected;
            set=>SetProperty(ref animalSelected, value);                           
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


        bool imageVector;
        public bool ImageVector
        {
            get => imageVector;
            set => SetProperty(ref imageVector, value);
        }

    
        #endregion

        #region COMMANDS
        public ICommand GetImageFromGalleryCommand { get; set; }

        public ICommand AddPetCommand { get; set; }

        public ICommand ClearFields { get; set; }

        #endregion

        public RegisterPetViewModel(IAnimalService IAnimalService,
                                    IImageContainerHelper ImageContainerHelper)
        {           
            _PetModelRepository = new PetModelRepository(App.dbPath);
            _IAnimalService = IAnimalService;
            _ImageContainerHelper = ImageContainerHelper;

            ImagePath = "image_vetor.svg";
            AnimalsList = _animalHelper.GetAllAnimals();
            ClearFields = new Command(OnClearFields);

            GetImageFromGalleryCommand = new Command(async () => await OnGetImageFromGalleryCommand());
            AddPetCommand = new Command(OnAddPetCommand);
        }

        #region METHODS
        private async void OnAddPetCommand()
        {
            PetModel pet = new PetModel();

            pet.Name = Name;
            pet.Animal = AnimalSelected.Value;
            pet.ImageData = ImagePath == "image_vetor.svg" ?
                            await _ImageContainerHelper.GetImageDefault(AnimalSelected.Value) :
                            await _ImageContainerHelper.ReadImageBytes(ImagePath);

            pet.BirthDate = BirthDate;
            pet.Color = Color;
            pet.Observation = Observation;
            pet.Sex = IsToggledSex == true ? "M" : "F";
            pet.Catrated = IsToggledCatrated;
            pet.Weight = Weight;
            pet.Age = 0;

            var result = await _PetModelRepository.SavePetAsync(pet);

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

        public void OnClearFields()
        {
            Name = string.Empty;
            AnimalSelected = new AnimalHelper();
            BreedSelected = new AnimalHelper();
            Color = string.Empty;
            Weight = 0;
            BirthDate = DateTime.Now;
            IsToggledSex = false;
            IsCastratedText = "Não";
            Observation = string.Empty;
        }


        public void ResetFieldsViewModel()
        {            
            Name = string.Empty;
            AnimalSelected = new AnimalHelper();
            Color = string.Empty;
            Weight = 0;
            BirthDate = DateTime.Now;
            IsToggledSex = false;
            IsToggledCatrated = false;
            Observation = string.Empty;
        }

        #endregion
    }

}
