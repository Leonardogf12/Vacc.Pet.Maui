using VaccPet.Helpers.Buttons;
using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views;

public partial class ListPetPage : ContentPage
{
    public ImageButtonAnimationHelper _imageButtonAnimationHelper;


    public ListPetPage(ListPetViewModel model)
    {
        InitializeComponent();
      
        this.BindingContext = model;

        _imageButtonAnimationHelper = new ImageButtonAnimationHelper();

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

  

    private async void Tapped_OpenPopup(object sender, TappedEventArgs e)
    {
        var element = sender as ImageButton;
        await _imageButtonAnimationHelper.AnimateScaleViewElement(element,0.8);

        var vm = BindingContext as ListPetViewModel;

        vm.SelectedPetInCollectionCommand.Execute(e.Parameter);
    }
}