﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Mopups.Hosting;
using Mopups.Interfaces;
using Mopups.Services;
using VaccPet.Data;
using VaccPet.MVVM.ViewModels;
using VaccPet.MVVM.Views;
using VaccPet.MVVM.Views.Components;
using VaccPet.Services;
using VaccPet.Services.Navigation;

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

        DBConnection.Instance.Initialize(); //*Transferido para este lugar devido a bug de inicialização na App. Testar essa chamada com Task.

        //*Views
        builder.Services.AddSingleton<HomePage>();
		builder.Services.AddSingleton<RegisterPetPage>();
		builder.Services.AddSingleton<ListPetPage>();

        builder.Services.AddTransient<PopupListActionsPage>();
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

        //*IF NECESSÁRIO PARA CORRIGIR BUG DA IMAGEM, PAGINAÇÃO TRAVANDO DEVIDO AO Converter={StaticResource ByteArrayToImageSourceConverter} em ListPetPage
#if __ANDROID__
        ImageHandler.Mapper.PrependToMapping(nameof(Microsoft.Maui.IImage.Source), (handler, view) => PrependToMappingImageSource(handler, view));
#endif
        return builder.Build();
	}

    //*IF NECESSÁRIO PARA CORRIGIR BUG DA IMAGEM, PAGINAÇÃO TRAVANDO DEVIDO AO Converter={StaticResource ByteArrayToImageSourceConverter} em ListPetPage
#if __ANDROID__
    public static void PrependToMappingImageSource(IImageHandler handler, Microsoft.Maui.IImage image)
    {
        handler.PlatformView?.Clear();
    }
#endif
}
