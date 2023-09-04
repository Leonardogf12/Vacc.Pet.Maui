using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views;

public partial class RegisterPetPage : ContentPage
{
    
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
            await DisplayAlert("Nome", "O campo Nome est� incorreto. Favor verificar.", "Ok");
            return false;
        }

        if(comboBoxAnimal.SelectedItem == null)
        {
            comboBoxAnimal.HasError = true;           
        }

        if (!colorBehaviorValidator.ValidateFields)
        {
            await DisplayAlert("Cor", "O campo Cor est� incorreto. Favor verificar.", "Ok");
            return false;
        }

        if (!weightBehaviorValidator.ValidateFields)
        {
            await DisplayAlert("Peso", "O campo Peso est� incorreto. Favor verificar.", "Ok");
            return false;
        }

        if (!birthDateBehaviorValidator.ValidateFields)
        {
            await DisplayAlert("Nascimento", "O campo Nascimento est� incorreto. Favor verificar.", "Ok");
            return false;
        }

        if (!observationBehaviorValidator.ValidateFields)
        {
            await DisplayAlert("Observa��o", "O campo Observa��o est� incorreto. Favor verificar.", "Ok");
            return false;
        }
                
        return true;
    }    

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await App.Current.MainPage.Navigation.PopAsync();
    }

    protected override void OnAppearing()
    {
        var vm = BindingContext as RegisterPetViewModel;
        vm.ImageVector = true;

        vm.ResetFieldsViewModel();

        base.OnAppearing();
    }
}