using Flappy_Miau.Resources.Localization;

namespace Flappy_Miau.Models;

public class GameDrawable : IDrawable
{
    public int Score { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // Draw the score
        canvas.FontColor = Colors.White;
        canvas.FontSize = 50;
        canvas.DrawString($"{AppResources.Score}: {Score}", 25, 25, 1000, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    }
}