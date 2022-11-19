using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SVGImageLoadSample.View;
using SVGImageLoadSample.ViewModel;

namespace SVGImageLoadSample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        //ViewModels
        builder.Services.AddSingleton<MainViewModel>();

        //Views
        builder.Services.AddSingleton<MainPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
