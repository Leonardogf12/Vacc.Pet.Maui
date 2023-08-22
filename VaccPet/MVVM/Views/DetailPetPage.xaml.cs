using VaccPet.Constants;
using VaccPet.MVVM.ViewModels;
using VaccPet.Services.Navigation;

namespace VaccPet.MVVM.Views;

public partial class DetailPetPage : ContentPage
{

    private readonly INavigationService _navigationService;

	public DetailPetPage(DetailPetViewModel model, INavigationService navigationService)
	{
        _navigationService  = navigationService;

		InitializeComponent();

		BindingContext = model;
	}
    
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var componentClicked = sender as Image;

        await _navigationService.GoBackAsync(StringConstants.GoBackOnce, componentClicked);
    }
}