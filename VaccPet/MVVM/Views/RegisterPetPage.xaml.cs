using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views;

public partial class RegisterPetPage : ContentPage
{
	public RegisterPetPage(RegisterPetViewModel model)
	{
		InitializeComponent();

		BindingContext = model;
	}

    
    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (NameValidator.IsNotValid)
        {
            imageValidationName.Source = "error.svg";
            return;
        }                
        else{
            imageValidationName.Source = "confirmation.svg";
        }

        if (ColorValidator.IsNotValid)
        {
            imageValidationColor.Source = "error.svg";
            return;
        }
        else
        {
            imageValidationColor.Source = "confirmation.svg";
        }
        
        if (pickerAnimal.SelectedItem != null)
        {
            imageValidationAnimal.Source = "confirmation.svg";
        }
        else{
            imageValidationAnimal.Source = "error.svg";
            return;
        }
       
        var vm = BindingContext as RegisterPetViewModel;

        vm.AddPetCommand.Execute(vm);
    }

    private void entryName_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length >= 3) 
            imageValidationName.Source = "confirmation.svg";        
        else        
            imageValidationName.Source = "error.svg";       
    }
    private void entryColor_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(e.NewTextValue.Length >= 4)
            imageValidationColor.Source = "confirmation.svg";
        else
            imageValidationColor.Source = "error.svg";
    }
    private void entryWeigth_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(double.Parse(e.NewTextValue) > 0.1)        
            imageValidationWeight.Source = "confirmation.svg";        
        else        
            imageValidationWeight.Source = "error.svg";        
    }
}