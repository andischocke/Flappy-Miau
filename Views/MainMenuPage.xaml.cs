using Flappy_Miau.ViewModels;

namespace Flappy_Miau.Views;

public partial class MainMenuPage : ContentPage
{
    public MainMenuPage(MainMenuViewModel mainMenuViewModel)
    {
        InitializeComponent();

        BindingContext = mainMenuViewModel;
    }
}