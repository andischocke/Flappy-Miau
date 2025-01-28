using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Flappy_Miau.Models;
using Flappy_Miau.Services;
using Flappy_Miau.Views;

namespace Flappy_Miau.ViewModels;

public partial class GameViewModel : ObservableObject
{
    public Database Database { get; set; }
    public Action? InvalidateGraphicsView { get; set; }

    [ObservableProperty]
    private GameDrawable gameDrawable;

    public GameViewModel(Database database)
    {
        Database = database;
        GameDrawable = new GameDrawable();
        GameDrawable.GameOver += GameOver;

        // Refresh framerate 60 times per second
        System.Timers.Timer timer = new System.Timers.Timer(1000 / 60);
        // Invalidate the GraphicsView and increment the score every time the timer elapses
        timer.Elapsed += (sender, e) => InvalidateGraphicsView?.Invoke();
        timer.Elapsed += (sender, e) => GameDrawable.Score++;
        // Start the timer
        timer.Start();
    }

    private async void GameOver()
    {
        await CreateScore(GameDrawable.Score);
        // Reset the game
        GameDrawable = new GameDrawable();
        GameDrawable.GameOver += GameOver;
        // Absolute navigation to the main menu page
        await Shell.Current.GoToAsync($"//{nameof(MainMenuPage)}");
    }

    [RelayCommand]
    public async Task CreateScore(int score)
    {
        await Database.CreateItem(new Score(DateTime.Now, score));
    }
}