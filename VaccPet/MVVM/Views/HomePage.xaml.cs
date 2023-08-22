using VaccPet.Helpers.Buttons;
using VaccPet.MVVM.ViewModels;
using VaccPet.Services.Navigation;

namespace VaccPet.MVVM.Views;

public partial class HomePage : ContentPage
{

    private readonly INavigationService _navigationService;

    public ImageButtonAnimationHelper _imageButtonAnimationHelper = new();


    public HomePage(HomeViewModel model, INavigationService navigationService)
    {        
        _navigationService = navigationService;

        InitializeComponent();

        this.BindingContext = model;
    }


    private async void TapGestureRecognizer_GoToPetPageList(object sender, TappedEventArgs e)
    {      
        var buttonSelected = sender as Frame;     

        await _navigationService.NavigateToPageAsync<ListPetPage>(null, buttonSelected);
    }

    private async void TapGestureRecognizer_PageByCardHorizontal(object sender, TappedEventArgs e)
    {
        var element = sender as Frame;
        await _imageButtonAnimationHelper.AnimateScaleViewElement(element);

        var vm = BindingContext as HomeViewModel;

        vm.NavigationMenuHorizontalCommand.Execute(e.Parameter);        
    }
}