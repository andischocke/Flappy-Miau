using Flappy_Miau.ViewModels;

namespace Flappy_Miau.Views;

public partial class MainMenuPage : ContentPage
{
    public MainMenuPage()
    {
        InitializeComponent();

        BindingContext = new MainMenuViewModel();
    }
}