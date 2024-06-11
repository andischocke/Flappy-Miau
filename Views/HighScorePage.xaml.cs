using Flappy_Miau.ViewModels;

namespace Flappy_Miau.Views;

public partial class HighScorePage : ContentPage
{
    public HighScorePage(HighScoreViewModel highScoreViewModel)
    {
        InitializeComponent();

        BindingContext = highScoreViewModel;
    }
}