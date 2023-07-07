using CommunityToolkit.Maui;
using Material.Components.Maui.Extensions;
using Microsoft.Extensions.Logging;
using VaccPet.Data;
using VaccPet.MVVM.ViewModels;
using VaccPet.MVVM.Views;
using VaccPet.Services;
using VaccPet.Services.Navigation;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Mopups.Hosting;
using Mopups.Interfaces;
using Mopups.Services;
using VaccPet.MVVM.Views.Components;

namespace VaccPet;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{        
        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureMopups()
			.UseMauiCommunityToolkit()			
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});



#if DEBUG
		builder.Logging.AddDebug();
#endif

        DBConnection.Instance.Initialize();

        //*Views
        builder.Services.AddSingleton<HomePage>();
		builder.Services.AddSingleton<RegisterPetPage>();
		builder.Services.AddSingleton<ListPetPage>();

        builder.Services.AddTransient<PopupConfirmationPage>();

        //*ViewModels
        builder.Services.AddSingleton<BaseViewModel>();
		builder.Services.AddSingleton<HomeViewModel>();
		builder.Services.AddSingleton<ListPetViewModel>();
		builder.Services.AddSingleton<RegisterPetViewModel>();

		//*Services
		builder.Services.AddSingleton<IPetService, PetService>();
		builder.Services.AddSingleton<INavigationService, NavigationService>();
		builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);


#if __ANDROID__
        ImageHandler.Mapper.PrependToMapping(nameof(Microsoft.Maui.IImage.Source), (handler, view) => PrependToMappingImageSource(handler, view));
#endif
        return builder.Build();
	}
#if __ANDROID__
    public static void PrependToMappingImageSource(IImageHandler handler, Microsoft.Maui.IImage image)
    {
        handler.PlatformView?.Clear();
    }
#endif
}
