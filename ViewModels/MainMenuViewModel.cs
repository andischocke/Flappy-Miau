using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace Flappy_Miau.ViewModels;

public partial class MainMenuViewModel : ObservableObject
{
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