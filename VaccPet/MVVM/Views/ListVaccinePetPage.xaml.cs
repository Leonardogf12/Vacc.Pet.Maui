using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views;

public partial class ListVaccinePetPage : ContentPage
{
    public ListVaccinePetPage()
    {
        InitializeComponent();

        BindingContext = new  ListVaccinePetViewModel();
    }
}