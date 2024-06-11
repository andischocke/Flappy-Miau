using Flappy_Miau.ViewModels;

namespace Flappy_Miau.Views;

public partial class GamePage : ContentPage
{
    public GamePage(GameViewModel gameViewModel)
    {
        InitializeComponent();

        BindingContext = gameViewModel;
    }
}