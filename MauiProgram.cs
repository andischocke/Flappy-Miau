using Microsoft.Extensions.Logging;

namespace Flappy_Miau;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder mauiAppBuilder = MauiApp.CreateBuilder();
        mauiAppBuilder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        mauiAppBuilder.Logging.AddDebug();
#endif

        return mauiAppBuilder.Build();
    }
}