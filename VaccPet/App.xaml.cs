using VaccPet.Data;
using VaccPet.MVVM.ViewModels;
using VaccPet.MVVM.Views;
using VaccPet.Services.Navigation;

namespace VaccPet;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        DependencyService.Register<NavigationService>();

        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(typeof(ListPetPage).FullName, typeof(ListPetPage));
        Routing.RegisterRoute(typeof(RegisterPetPage).FullName, typeof(RegisterPetPage));

        MainPage = new MainPage();
	}

    //protected override async void OnStart()
    //{
    //    base.OnStart();
    //    await DBConnection.Instance.Initialize();
    //}
}
