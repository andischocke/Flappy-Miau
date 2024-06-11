using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Flappy_Miau.Views;
using System.Diagnostics;

namespace Flappy_Miau.ViewModels;

public partial class MainMenuViewModel : ObservableObject
{
    [RelayCommand]
    public void NewGame()
    {
        // Absolute navigation to the game page
        Shell.Current.GoToAsync($"//{nameof(GamePage)}");
    }

    [RelayCommand]
    public void HighScore()
    {
        // Relative navigation to the high score page
        Shell.Current.GoToAsync($"{nameof(HighScorePage)}");
    }

    [RelayCommand]
    public void ExitGame()
    {
        Process.GetCurrentProcess().Kill();
    }
}