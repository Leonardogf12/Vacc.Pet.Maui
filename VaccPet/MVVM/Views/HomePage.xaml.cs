using Mopups.Interfaces;
using Mopups.Services;
using VaccPet.MVVM.ViewModels;
using VaccPet.MVVM.Views.Components;

namespace VaccPet.MVVM.Views;

public partial class HomePage : ContentPage
{  
	public HomePage(HomeViewModel model, IPopupNavigation popupNavigation)
	{
		InitializeComponent();

        this.BindingContext = model;
    }

}