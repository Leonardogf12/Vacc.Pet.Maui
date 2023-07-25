using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views;

public partial class RegisterVaccinePetPage : ContentPage
{
	public RegisterVaccinePetPage(RegisterVaccinePetViewModel model)
	{
		InitializeComponent();

		BindingContext = model;
	}
}