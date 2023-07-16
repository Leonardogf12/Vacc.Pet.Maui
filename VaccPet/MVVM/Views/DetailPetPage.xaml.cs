using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views;

public partial class DetailPetPage : ContentPage
{
	public DetailPetPage(DetailPetViewModel model)
	{
		InitializeComponent();

		BindingContext = model;
	}
    
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await App.Current.MainPage.Navigation.PopAsync();
    }
}