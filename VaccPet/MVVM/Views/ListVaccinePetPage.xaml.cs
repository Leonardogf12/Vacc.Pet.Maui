using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views;

public partial class ListVaccinePetPage : ContentPage
{
    public ListVaccinePetPage(ListVaccinePetViewModel model)
    {
        InitializeComponent();

        BindingContext = model;
    }
}