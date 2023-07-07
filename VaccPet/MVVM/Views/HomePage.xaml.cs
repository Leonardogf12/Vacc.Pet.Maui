using Mopups.Interfaces;
using Mopups.Services;
using VaccPet.MVVM.ViewModels;
using VaccPet.MVVM.Views.Components;

namespace VaccPet.MVVM.Views;

public partial class HomePage : ContentPage
{
    IPopupNavigation popupNavigation;
	public HomePage(HomeViewModel model, IPopupNavigation popupNavigation)
	{
		InitializeComponent();

        this.popupNavigation = popupNavigation;
		
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