using CommunityToolkit.Mvvm.ComponentModel;
using Flappy_Miau.Models;

namespace Flappy_Miau.ViewModels;

public partial class GameViewModel : ObservableObject
{
    public Action? InvalidateGraphicsView { get; set; }

    [ObservableProperty]
    private GameDrawable gameDrawable;

    public GameViewModel()
    {
        GameDrawable = new GameDrawable();

        // Refresh framerate 60 times per second
        System.Timers.Timer timer = new System.Timers.Timer(1000 / 60);
        // Invalidate the GraphicsView and increment the score every time the timer elapses
        timer.Elapsed += (sender, e) => InvalidateGraphicsView?.Invoke();
        timer.Elapsed += (sender, e) => GameDrawable.Score++;
        // Start the timer
        timer.Start();
    }
}