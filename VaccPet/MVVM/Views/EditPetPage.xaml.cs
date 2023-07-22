using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views;

public partial class EditPetPage : ContentPage
{
	public EditPetPage(EditPetViewModel model)
	{
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
}