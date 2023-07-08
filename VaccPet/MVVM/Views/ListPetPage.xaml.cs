using Mopups.Interfaces;
using Mopups.Services;
using VaccPet.MVVM.ViewModels;
using VaccPet.MVVM.Views.Components;

namespace VaccPet.MVVM.Views;

public partial class ListPetPage : ContentPage
{
    IPopupNavigation popupNavigation;
    public ListPetPage(ListPetViewModel model, IPopupNavigation popupNavigation)
    {
        InitializeComponent();

        this.popupNavigation = popupNavigation;

        this.BindingContext = model;        
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as ListPetViewModel;
        vm.OnAppearing();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as ListPetViewModel;
        vm.OnSelectedPetInCollectionCommand();
    }

    //private void Test(object sender, EventArgs e)
    //{
    //    popupNavigation.PushAsync(new PopupConfirmationPage(null), true);
    //}
}