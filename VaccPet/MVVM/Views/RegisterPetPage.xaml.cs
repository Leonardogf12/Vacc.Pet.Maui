using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views;

public partial class RegisterPetPage : ContentPage
{
    RegisterPetViewModel _model;
    public RegisterPetPage(RegisterPetViewModel model)
	{
		InitializeComponent();

		BindingContext = model;
        
    }

    
    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        var result = await ValidateFieldsRegisterPet();
        
        if(result) 
        {
            var vm = BindingContext as RegisterPetViewModel;
            vm.AddPetCommand.Execute(vm);
        }       

        return;
    }

    private async Task<bool> ValidateFieldsRegisterPet()
    {
        if (!nameBehaviorValidator.ValidateFields)
        {
            await DisplayAlert("Nome", "O campo Nome está incorreto. Favor verificar.", "Ok");
            return false;
        }

        if(comboBoxAnimal.SelectedItem == null)
        {
            comboBoxAnimal.HasError = true;           
        }

        if (!colorBehaviorValidator.ValidateFields)
        {
            await DisplayAlert("Cor", "O campo Cor está incorreto. Favor verificar.", "Ok");
            return false;
        }

        if (!weightBehaviorValidator.ValidateFields)
        {
            await DisplayAlert("Peso", "O campo Peso está incorreto. Favor verificar.", "Ok");
            return false;
        }

        if (!birthDateBehaviorValidator.ValidateFields)
        {
            await DisplayAlert("Nascimento", "O campo Nascimento está incorreto. Favor verificar.", "Ok");
            return false;
        }

        if (!observationBehaviorValidator.ValidateFields)
        {
            await DisplayAlert("Observação", "O campo Observação está incorreto. Favor verificar.", "Ok");
            return false;
        }
                
        return true;
    }

    protected override void OnAppearing()
    {
        var vm = BindingContext as RegisterPetViewModel;
        vm.ImageVector = true;

        base.OnAppearing();
    }

}