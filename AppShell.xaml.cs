using Flappy_Miau.Views;

namespace Flappy_Miau;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(MainMenuPage), typeof(MainMenuPage));
        Routing.RegisterRoute(nameof(GamePage), typeof(GamePage));
        Routing.RegisterRoute(nameof(HighScorePage), typeof(HighScorePage));
    }
}