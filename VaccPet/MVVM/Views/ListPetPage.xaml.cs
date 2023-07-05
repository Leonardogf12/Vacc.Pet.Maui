using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views;

public partial class ListPetPage : ContentPage
{
	public ListPetPage(ListPetViewModel model)
	{
		InitializeComponent();

		this.BindingContext = model;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as ListPetViewModel;
        vm.OnAppearing();
    }
}