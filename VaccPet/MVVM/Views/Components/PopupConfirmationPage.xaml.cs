using Mopups.Services;
using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views.Components;

public partial class PopupConfirmationPage
{
    public PopupConfirmationPage(PopupViewModel model)
    {
        InitializeComponent();

        BindingContext = model;

       // CloseWhenBackgroundIsClicked = true;
    }

    private void ButtonEdit_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }

    private void ButtonDelete_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }
}