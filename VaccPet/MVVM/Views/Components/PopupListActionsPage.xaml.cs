using CommunityToolkit.Maui.Views;
using Mopups.Services;
using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Views.Components;

public partial class PopupListActionsPage : Popup
{
    public PopupListActionsPage(PopupViewModel model)
    {
        InitializeComponent();

        BindingContext = model;
    }
    
}