using VaccPet.Helpers.Models;
using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views;

public partial class RegisterVaccinePetPage : ContentPage
{
    public VaccineHelper _vaccineHelper { get; set; } = new();

    //public RegisterVaccinePetViewModel ViewModel;


    public RegisterVaccinePetPage(RegisterVaccinePetViewModel model)
    {
        InitializeComponent();

        BindingContext = model;

       //ViewModel = BindingContext as RegisterVaccinePetViewModel;
    }

    
    private async void btnConfirmVaccine_Clicked(object sender, EventArgs e)
    {
        var result = await ValidateFieldsRegisterPet();

        if (result)
        {
            var vm = BindingContext as RegisterVaccinePetViewModel;
            vm.AddVaccinePetCommand.Execute(vm);
        }

        return;        
    }

    public async Task<bool> ValidateFieldsRegisterPet()
    {
        var ViewModel = BindingContext as RegisterVaccinePetViewModel;


        if (!VacinationDateBehaviorValidator.ValidateFields)
        {
            await DisplayAlert("Data da Vacina", "O campo 'Data da Vacina' está incorreto. Favor verificar.", "Ok");
            ViewModel.IsToggledAllOk = false;
            return false;
        }

        if (comboBoxAnimal.SelectedItem == null)
        {
            ViewModel.IsToggledAllOk = false;
            comboBoxAnimal.HasError = true;
        }

        if (!WeightBehaviorValidator.ValidateFields)
        {
            await DisplayAlert("Peso", "O campo Peso está incorreto. Favor verificar.", "Ok");
            ViewModel.IsToggledAllOk = false;
            return false;
        }

        return true;
    }

    protected override void OnAppearing()
    {
        var ViewModel = BindingContext as RegisterVaccinePetViewModel;

        var specie = ViewModel.RegisterVaccinePet.Animal;

        ViewModel.VaccineList = _vaccineHelper.GetVaccines(specie);

        ViewModel.ResetFields();

        base.OnAppearing();
    }
}