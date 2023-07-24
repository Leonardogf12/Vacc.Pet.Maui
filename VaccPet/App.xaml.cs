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
        Routing.RegisterRoute(nameof(DetailPetPage), typeof(DetailPetPage));
        Routing.RegisterRoute(nameof(EditPetPage), typeof(EditPetPage));
        Routing.RegisterRoute(nameof(ListVaccinePetPage), typeof(ListVaccinePetPage));
        MainPage = new MainPage();
	}

    //protected override async void OnStart()
    //{
    //    base.OnStart();
    //    await DBConnection.Instance.Initialize();
    //}
}
