using VaccPet.Helpers.Buttons;
using VaccPet.MVVM.ViewModels;
using VaccPet.Services.Navigation;

namespace VaccPet.MVVM.Views;

public partial class ListVaccinePetPage : ContentPage
{

    private readonly INavigationService _navigationService;

    public ImageButtonAnimationHelper _imageButtonAnimationHelper;

    public ListVaccinePetPage(ListVaccinePetViewModel model, INavigationService navigationService)
    {   
        _navigationService = navigationService;

        _imageButtonAnimationHelper = new ImageButtonAnimationHelper();

        InitializeComponent();

        BindingContext = model;
    }

    private async void TapGestureRecognizer_GoBackIcon(object sender, TappedEventArgs e)
    {
        ImageButtonAnimationHelper btnAdd = new ImageButtonAnimationHelper();

        var image = sender as Image;

        await _imageButtonAnimationHelper.AnimateScaleViewElement(image);

        await _navigationService.GoBackAsync("..");
    }
}