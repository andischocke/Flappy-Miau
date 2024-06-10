using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace Flappy_Miau.ViewModels;

public partial class MainMenuViewModel : ObservableObject
{
    [ObservableProperty]
    public string mainMenu;

    [ObservableProperty]
    public string newGameButton;

    [ObservableProperty]
    public string highScoreButton;

    [ObservableProperty]
    public string exitGameButton;

    public MainMenuViewModel()
    {
        mainMenu = "Main Menu";
        newGameButton = "New Game";
        highScoreButton = "High Score";
        exitGameButton = "Exit Game";
    }

    [RelayCommand]
    public void NewGame()
    {

    }

    [RelayCommand]
    public void HighScore()
    {

    }

    [RelayCommand]
    public void ExitGame()
    {
        Process.GetCurrentProcess().Kill();
    }
}