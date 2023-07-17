using Mopups.Interfaces;
using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views;

public partial class HomePage : ContentPage
{  
	public HomePage(HomeViewModel model, IPopupNavigation popupNavigation)
	{
		InitializeComponent();

        this.BindingContext = model;
    }

    private async void OnFrameTapped(object sender, EventArgs e)
    {
        var frame = (Frame)sender;
        frame.Opacity = 0.3;
        frame.Opacity = 1;      
    }
   
}