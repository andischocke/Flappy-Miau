using Flappy_Miau.ViewModels;

namespace Flappy_Miau.Views;

public partial class GamePage : ContentPage
{
    public GamePage(GameViewModel gameViewModel)
    {
        InitializeComponent();

        BindingContext = gameViewModel;
        // Set the InvalidateGraphicsView action to the Invalidate method of the GraphicsView
        gameViewModel.InvalidateGraphicsView = () => GraphicsView.Invalidate();
    }
}