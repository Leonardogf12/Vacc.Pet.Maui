using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views;

public partial class RegisterPetPage : ContentPage
{
	public RegisterPetPage(RegisterPetViewModel model)
	{
		InitializeComponent();

		BindingContext = model;
	}  
}