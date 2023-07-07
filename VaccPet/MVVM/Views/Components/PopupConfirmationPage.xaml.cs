using Mopups.Services;

namespace VaccPet.MVVM.Views.Components;

public partial class PopupConfirmationPage
{
	public PopupConfirmationPage()
	{
		InitializeComponent();
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