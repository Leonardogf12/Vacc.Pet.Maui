using CommunityToolkit.Maui.Views;
using DevExpress.Maui.Core.Internal;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VaccPet.MVVM.Models;
using VaccPet.MVVM.Views;
using VaccPet.MVVM.Views.Components;
using VaccPet.Repositories;
using static System.Collections.Specialized.NameObjectCollectionBase;
using static VaccPet.Mokup.VaccineMokupHelper;

namespace VaccPet.MVVM.ViewModels
{
    [QueryProperty(nameof(PetSelectedForVaccine), "PetSelectedForVaccine")]
    public class ListVaccinePetViewModel : BaseViewModel
    {

        #region VARIABLES

        private readonly VaccineModelRepository _VaccineModelRepository;

        #endregion

        #region PROPS

        private PetModel _petSelectedForVaccine;
        public PetModel PetSelectedForVaccine
        {
            get => _petSelectedForVaccine;
            set
            {
                SetProperty(ref _petSelectedForVaccine, value);

                GetAllVaccinesOfPetSelected();
            }
        }


        private ObservableCollection<VaccineModel> _vaccineModelCollection;
        public ObservableCollection<VaccineModel> VaccineModelCollection
        {
            get => _vaccineModelCollection;
            set => SetProperty(ref _vaccineModelCollection, value);
        }


        private int _vaccineCount;
        public int VaccineCount
        {
            get => _vaccineCount;
            set => SetProperty(ref _vaccineCount, value);
        }


        private string _revaccinationColor = "DeepPink";
        public string RevaccinationColor
        {
            get => _revaccinationColor;
            set => SetProperty(ref _revaccinationColor, value);
        }

        #endregion

        #region COMMANDS

        public ICommand AddVaccinePetCommand { get; set; }
        public Command RemoveVaccineItem { get; set; }
        public Command InformVaccinationCommand { get; set; }

        #endregion

        public ListVaccinePetViewModel()
        {
            VaccineModelCollection = new ObservableCollection<VaccineModel>();

            _VaccineModelRepository = new VaccineModelRepository(App.dbPath);

            AddVaccinePetCommand = new Command(OnAddVaccinePetCommand);

            RemoveVaccineItem = new Command<VaccineModel>(OnRemoveVaccineItem);

            InformVaccinationCommand = new Command<VaccineModel>(OnInformVaccinationCommand);
        }

        private async void OnInformVaccinationCommand(VaccineModel model)
        {

            var result = await App.Current.MainPage.DisplayAlert("Alterar", "Deseja lançar a segunda dose a está vacina?." +
                " Ao lançar a segunda dose, a primeira dose automaticamente receberá o status de concluída.", "Sim", "Não");

            if (result)
            {
               //TODO Criar Popup para preencher os mesmos campos de RegisterVaccinePetPage. Com isso o registro clicado recebe status de concluido
               // e um novo será lancado com a nova data de vacina e revacina, o registro concluido não poderá ser editado.
               //assim que o novo registro for salvo deve subir para primeira posição da lista e o registro concluido deve descer na fila.
               //a cor da data do campo de "Revacinar em:" do card concluido deve mudar para GreenYellow e o icone de edit deve mudar para Check_green.
               //*******PENSAR EM UMA FORMA DE CORRECAO CASO O USUARIO QUEIRA CORRIGIR UMA FALHA DE DIGITAÇÃO (PERMITIR OU APAGAR PARA REFAZER)
            }
        }

        private async void OnRemoveVaccineItem(VaccineModel model)
        {
            var question = await App.Current.MainPage.DisplayAlert("Excluir", "Deseja realmente exlcuir este registro?", "Sim", "Não");

            if (!question) return;

            VaccineModelCollection.Remove(model);

            var result = await _VaccineModelRepository.DeleteVaccineAsync(model);

            if (result > 0)            
                await App.Current.MainPage.ShowPopupAsync(new PopupSuccessConfirmationPage());                       
            else            
                await App.Current.MainPage.ShowPopupAsync(new PopupErrorConfirmationPage());                          
        }

        private async void GetAllVaccinesOfPetSelected()
        {
            VaccineModelCollection = new ObservableCollection<VaccineModel>();

            var listVaccines = await _VaccineModelRepository.GetAllVaccinesByPetAsync(PetSelectedForVaccine.Id);

            VaccineModelCollection.Clear();

            foreach (var item in listVaccines)
            {
                VaccineModelCollection.Add(item);
            }

            VaccineCount = VaccineModelCollection.Count;
        }

        private async void OnAddVaccinePetCommand()
        {
            PetModel petModel = (PetModel)PetSelectedForVaccine;

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "RegisterVaccinePet", petModel },
            };

            await Navigation.NavigateToPageAsync<RegisterVaccinePetPage>(parameters);
        }

    }
}
