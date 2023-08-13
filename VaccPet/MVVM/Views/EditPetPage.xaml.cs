using VaccPet.MVVM.ViewModels;
using VaccPet.Services.Navigation;

namespace VaccPet.MVVM.Views;

public partial class EditPetPage : ContentPage
{
    private readonly INavigationService _navigationService;
	public EditPetPage(EditPetViewModel model, INavigationService navigationService)
	{
        _navigationService = navigationService;

		InitializeComponent();

		BindingContext = model;
	}

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as EditPetViewModel;
        vm.UpdatePetCommand.Execute(vm);

        return;
    }

    protected override void OnAppearing()
    {
        var vm = BindingContext as EditPetViewModel;
        vm.ImagePath = string.Empty;
        vm.ImageVector = true;

       vm.OnSetDetailsPetCommand();

        base.OnAppearing();
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var componentClicked = sender as Image;

        await _navigationService.GoBackAsync("..", componentClicked);        
    }
}