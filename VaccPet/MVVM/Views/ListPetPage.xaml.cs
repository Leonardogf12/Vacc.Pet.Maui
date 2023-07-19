using Mopups.Interfaces;
using Mopups.Services;
using VaccPet.Helpers.Buttons;
using VaccPet.MVVM.ViewModels;
using VaccPet.MVVM.Views.Components;

namespace VaccPet.MVVM.Views;

public partial class ListPetPage : ContentPage
{

    public ListPetPage(ListPetViewModel model)
    {
        InitializeComponent();
      
        this.BindingContext = model;

        ImageButtonAnimationHelper btnAdd = new ImageButtonAnimationHelper();
        ImageButtonAnimationHelper btnDelete = new ImageButtonAnimationHelper();
        btnAdd.AddButtonAnimation(btnAddPet,"add_circle", "add_circle_green");
        btnDelete.AddButtonAnimation(btnDeleteAll, "trash", "trash_red");
    }
   
    protected override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as ListPetViewModel;
        vm.OnAppearing();
    }    
}