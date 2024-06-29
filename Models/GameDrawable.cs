using Flappy_Miau.Resources.Localization;

namespace Flappy_Miau.Models;

public class GameDrawable : IDrawable
{
    private double DisplayWidth { get; set; }
    private double DisplayHeight { get; set; }
    private (RectF Upper, Rect Lower) Bounds { get; set; }
    public int Score { get; set; }

    public GameDrawable()
    {
        // Get Display Width and Display Height
        DisplayWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
        DisplayHeight = (DeviceDisplay.MainDisplayInfo.Height - 100) / DeviceDisplay.MainDisplayInfo.Density;

        // Set the bounds
        Bounds = (new RectF(0, 0, (float)DisplayWidth, 20), new RectF(0, (float)DisplayHeight - 20, (float)DisplayWidth, 20));
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // Draw the bounds
        canvas.FillColor = Colors.Green;
        canvas.FillRectangle(Bounds.Upper);
        canvas.FillRectangle(Bounds.Lower);

        // Draw the score
        canvas.FontColor = Colors.White;
        canvas.FontSize = 50;
        canvas.DrawString($"{AppResources.Score}: {Score}", 25, 25, 1000, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    }
}