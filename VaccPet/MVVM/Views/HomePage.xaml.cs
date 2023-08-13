using VaccPet.Helpers.Buttons;
using VaccPet.MVVM.ViewModels;
using VaccPet.Services.Navigation;

namespace VaccPet.MVVM.Views;

public partial class HomePage : ContentPage
{
    private readonly INavigationService _navigationService;

    public HomePage(HomeViewModel model, INavigationService navigationService)
    {
        _navigationService = navigationService;

        InitializeComponent();

        this.BindingContext = model;
    }


    private async void TapGestureRecognizer_GoToPetList(object sender, TappedEventArgs e)
    {
        ImageButtonAnimationHelper btnHelper = new ImageButtonAnimationHelper();

        var buttonSelected = sender as Frame;     

        await _navigationService.NavigateToPageAsync<ListPetPage>(null, buttonSelected);
    }
}