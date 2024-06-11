using Flappy_Miau.ViewModels;
using Flappy_Miau.Views;
using Microsoft.Extensions.Logging;

namespace Flappy_Miau;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder mauiAppBuilder = MauiApp.CreateBuilder();
        mauiAppBuilder
            .UseMauiApp<App>()
            .ConfigureFonts(RegisterFonts)
            .RegisterViewModels()
            .RegisterViews();

#if DEBUG
        mauiAppBuilder.Logging.AddDebug();
#endif

        return mauiAppBuilder.Build();
    }

    public static void RegisterFonts(IFontCollection fonts)
    {
        fonts.AddFont("FontAwesome-Sharp-Regular-400.ttf", "FontAwesome");
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<GameViewModel>();
        mauiAppBuilder.Services.AddTransient<HighScoreViewModel>();
        mauiAppBuilder.Services.AddTransient<MainMenuViewModel>();
        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<GamePage>();
        mauiAppBuilder.Services.AddTransient<HighScorePage>();
        mauiAppBuilder.Services.AddTransient<MainMenuPage>();
        return mauiAppBuilder;
    }
}