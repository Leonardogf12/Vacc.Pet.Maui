using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using VaccPet.Helpers.Models;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views.Components;
using VaccPet.Services;

namespace VaccPet.MVVM.ViewModels
{
    public class RegisterPetViewModel : BaseViewModel
    {
        #region VARIABLES

        private readonly IPetService _IPetService;

        public List<Animal> AnimalsList { get; set; } = new List<Animal>();        

        public Animal AnimalHelper { get; set; } = new Animal();

        #endregion

        #region COMMANDS
        public ICommand GetImageFromGalleryCommand { get; set; }

        public ICommand AddPetCommand { get; set; }

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

        string observation;
        public string Observation
        {
            get => observation;
            set => SetProperty(ref this.observation, value);
        }

        bool isCheckedF;
        public bool IsCheckedF
        {
            get
            {
                if (isCheckedF)
                {
                    IsCheckedM = false;
                }

                return isCheckedF;
            }
            set => SetProperty(ref isCheckedF, value);
        }

        bool isCheckedM;
        public bool IsCheckedM
        {
            get
            {
                if (isCheckedM)
                {
                    IsCheckedF = false;
                }

                return isCheckedM;
            }
            set => SetProperty(ref isCheckedM, value);
        }

        bool isCatrated;
        public bool IsCatrated
        {
            get
            {
                if (isCatrated)
                    IsCastratedConfirm = "Sim";
                else
                    IsCastratedConfirm = "Não";

                return isCatrated;
            }

            //
            set => SetProperty(ref isCatrated, value);
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

        private List<Animal> breedsList;
        public List<Animal> BreedsList
        {
            get => breedsList;
            set => SetProperty(ref breedsList, value);            
        }
       
        Animal breedSelected;
        public Animal BreedSelected
        {
            get => breedSelected;
            set => SetProperty(ref breedSelected, value);
        }

        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }

        string isCastratedConfirm = "Não";
        public string IsCastratedConfirm
        {
            get => isCastratedConfirm;
            set => SetProperty(ref isCastratedConfirm, value);
        }

        bool isToggledSex = false;
        public bool IsToggledSex
        {
            get => isToggledSex;
            set => SetProperty(ref isToggledSex, value);
        }

        #endregion

        public RegisterPetViewModel(IPetService IPetService)
        {
            _IPetService = IPetService;

            AnimalsList = AnimalHelper.GetAllAnimals();

            GetImageFromGalleryCommand = new Command(OnGetImageFromGalleryCommand);

            AddPetCommand = new Command(OnAddPetCommand);

        }

        #region METHODS
        private async void OnAddPetCommand()
        {
            PetModel pet = new PetModel();

            pet.Name = Name;
            pet.Animal = AnimalSelected.Value;
            pet.ImageData = ImagePath == null ? await GetImageDefault(AnimalSelected.Value) : await ReadImageBytes(ImagePath);
            pet.BirthDate = BirthDate;
            pet.Color = Color;
            pet.Observation = Observation;
            pet.Sex = IsToggledSex == true ? "M" : "F";
            pet.Catrated = IsCatrated;
            pet.Weight = Weight;
            pet.Age = 0;
            pet.Breed = BreedSelected.Value;

            var result = await _IPetService.AddPet(pet);

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

        private async Task<byte[]> ReadImageBytes(string imagePath)
        {
            try
            {
                using (FileStream stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] imageData = new byte[stream.Length];
                    await stream.ReadAsync(imageData, 0, (int)stream.Length);

                    return imageData;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async static Task<byte[]> GetImageDefault(string type)
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("noimage.png");
            return await StreamToByteArrayAsync(stream);
        }

        public static async Task<byte[]> StreamToByteArrayAsync(Stream stream)
        {
            using MemoryStream memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
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
                BreedsList = new List<Animal> { new Animal { Key = 1000, Value = "Raças não encontradas." } };
            }
        }

        #endregion
    }
}
