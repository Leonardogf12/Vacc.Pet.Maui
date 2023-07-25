using Microsoft.Maui.Dispatching;
using VaccPet.Helpers.Models;
using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views;

public partial class RegisterVaccinePetPage : ContentPage
{
    public VaccineHelper _vaccineHelper { get; set; } = new VaccineHelper();

    public RegisterVaccinePetPage(RegisterVaccinePetViewModel model)
    {
        InitializeComponent();

        BindingContext = model;
    }

    protected override void OnAppearing()
    {
        var vm = BindingContext as RegisterVaccinePetViewModel;
        var specie = vm.RegisterVaccinePet.Animal;
        vm.VaccineList = _vaccineHelper.GetVaccines(specie);

        base.OnAppearing();
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
        if (!VacinationDateBehaviorValidator.ValidateFields)
        {
            await DisplayAlert("Data da Vacina", "O campo 'Data da Vacina' está incorreto. Favor verificar.", "Ok");
            return false;
        }

        if (comboBoxAnimal.SelectedItem == null)
        {
            comboBoxAnimal.HasError = true;
        }

        if (!WeightBehaviorValidator.ValidateFields)
        {
            await DisplayAlert("Peso", "O campo Peso está incorreto. Favor verificar.", "Ok");
            return false;
        }

        return true;
    }
}