using VaccPet.Helpers;
using VaccPet.MVVM.Models;
using VaccPet.Services;
using System.IO;
using System.Resources;
using Microsoft.Extensions.FileProviders;
using Microsoft.Maui.Storage;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using VaccPet.MVVM.Views.Components;

namespace VaccPet.MVVM.ViewModels
{
    public class RegisterPetViewModel : BaseViewModel
    {
        #region VARIABLES

        private readonly IPetService _IPetService;

        public List<Animal> AnimalsList { get; set; } = new List<Animal>();

        Popup PopupConfirmationControl { get; set; }

        PopupViewModel PopupViewModel { get; set; } = new PopupViewModel();

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

        List<Animal> animals;
        public List<Animal> Animals
        {
            get => animals;
            set => SetProperty(ref this.animals, value);
        }

        double weight;
        public double Weight
        {
            get => weight;
            set => SetProperty(ref this.weight, value);
        }

        string sex;
        public string Sex
        {
            get => sex;
            set => SetProperty(ref this.sex, value);
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
            set => SetProperty(ref animalSelected, value);
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
            set=>  SetProperty(ref isCastratedConfirm, value); 
        }

        bool everythingOk;
        public bool EverythingOk
        {
            get => everythingOk;
            set=>SetProperty(ref everythingOk, value);
        }

        #endregion

        public RegisterPetViewModel(IPetService IPetService)
        {
            _IPetService = IPetService;

            AnimalsList = GetAllAnimals();

            GetImageFromGalleryCommand = new Command(OnGetImageFromGalleryCommand);

            AddPetCommand = new Command(OnAddPetCommand);
           
        }

        #region METHODS
        private async void OnAddPetCommand()
        {
            if (!EverythingOk)
            {
                await App.Current.MainPage.ShowPopupAsync(new PopupErrorConfirmationPage());
                return;
            }            

            PetModel pet = new PetModel();

            pet.Name = Name;
            pet.Animal = AnimalSelected.Value;
            pet.ImageData = ImagePath == null ? await GetImageDefault(AnimalSelected.Value) : await ReadImageBytes(ImagePath);
            pet.BirthDate = BirthDate;
            pet.Color = Color;
            pet.Observation = Observation;
            pet.Sex = IsCheckedF == true ? "F" : "M";
            pet.Catrated = IsCatrated;
            pet.Weight = Weight;

            var result = await _IPetService.AddPet(pet);

            if (result > 0)
            {                            
                await App.Current.MainPage.ShowPopupAsync(new PopupSuccessConfirmationPage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Ops, parece que algo deu errado. Tente novamente.", "OK");
                return;
            }

        }
        public List<Animal> GetAllAnimals()
        {
            return new List<Animal>()
            {
                new Animal{Key = 1, Value = "Cachorro"},
                new Animal{Key = 2, Value = "Gato"},
                new Animal{Key = 3, Value = "Peixe"},
                new Animal{Key = 4, Value = "Pássaro"},
                new Animal{Key = 5, Value = "Coelho"},
                new Animal{Key = 6, Value = "Hamster"},
                new Animal{Key = 7, Value = "Tartaruga"},
                new Animal{Key = 8, Value = "Porquinho-da-índia"},
                new Animal{Key = 9, Value = "Furão"},
                new Animal{Key = 10, Value = "Chinchila"},
                new Animal{Key = 11, Value = "Rato"},
                new Animal{Key = 12, Value = "Gerbil"},
                new Animal{Key = 13, Value = "Cobra"},
                new Animal{Key = 14, Value = "Lagarto"},
                new Animal{Key = 15, Value = "Cavalo"},
                new Animal{Key = 16, Value = "Porco"},
            };
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
            if (type == "Cachorro")
            {
                using var streamDog = await FileSystem.OpenAppPackageFileAsync("dogdefault.png");
                return await StreamToByteArrayAsync(streamDog);
            }
            if (type == "Gato")
            {
                using var streamCat = await FileSystem.OpenAppPackageFileAsync("catdefault.png");
                return await StreamToByteArrayAsync(streamCat);
            }
            if (type == "Coelho")
            {
                using var streamRab = await FileSystem.OpenAppPackageFileAsync("rabbitdefault.png");
                return await StreamToByteArrayAsync(streamRab);
            }
            if (type == "Hamster" || type == "Rato")
            {
                using var streamMou = await FileSystem.OpenAppPackageFileAsync("mousedefault.png");
                return await StreamToByteArrayAsync(streamMou);
            }

            using var stream = await FileSystem.OpenAppPackageFileAsync("noimage.png"); 
            return await StreamToByteArrayAsync(stream);
        }
        public static async Task<byte[]> StreamToByteArrayAsync(Stream stream)
        {
            using MemoryStream memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
        #endregion
    }
}
