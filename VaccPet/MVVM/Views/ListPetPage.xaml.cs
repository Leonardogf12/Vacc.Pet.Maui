using Mopups.Interfaces;
using Mopups.Services;
using VaccPet.MVVM.ViewModels;
using VaccPet.MVVM.Views.Components;

namespace VaccPet.MVVM.Views;

public partial class ListPetPage : ContentPage
{   
    public ListPetPage(ListPetViewModel model, IPopupNavigation popupNavigation)
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