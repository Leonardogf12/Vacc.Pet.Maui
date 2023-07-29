﻿using VaccPet.Data;
using VaccPet.MVVM.Views;
using VaccPet.Services.Navigation;

namespace VaccPet;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        // Initialize database before use
        var database = Database;

        DependencyService.Register<NavigationService>();

        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(typeof(ListPetPage).FullName, typeof(ListPetPage));
        Routing.RegisterRoute(typeof(RegisterPetPage).FullName, typeof(RegisterPetPage));       
        Routing.RegisterRoute(nameof(DetailPetPage), typeof(DetailPetPage));
        Routing.RegisterRoute(nameof(EditPetPage), typeof(EditPetPage));
        Routing.RegisterRoute(nameof(ListVaccinePetPage), typeof(ListVaccinePetPage));
        Routing.RegisterRoute(nameof(RegisterVaccinePetPage), typeof(RegisterVaccinePetPage));
        MainPage = new MainPage();
	}

    //protected override async void OnStart()
    //{
    //    base.OnStart();
    //    await DBConnection.Instance.Initialize();
    //}

    #region DATABASE
    private static Database database;

    public static Database Database
    {
        get
        {
            if (database == null)
            {
                database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "vaccpet.db3"));
            }

            return database;
        }
    }

    public const string dbPath = "/data/user/0/com.companyname.vaccpet/files/vaccpet.db3";
    #endregion
}
