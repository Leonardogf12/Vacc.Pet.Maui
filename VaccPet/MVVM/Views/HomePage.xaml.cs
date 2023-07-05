using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel model)
	{
		InitializeComponent();

		this.BindingContext = model;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await App.Current.MainPage.DisplayAlert("Titulo", "esta e uma mensagem de teste", "Fechar");
    }

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();

    //    var vm = BindingContext as HomeViewModel;
    //    vm.OnAppearing();
    //}    
}