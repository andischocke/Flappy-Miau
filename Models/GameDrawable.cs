using Flappy_Miau.Resources.Localization;

namespace Flappy_Miau.Models;

public class GameDrawable : IDrawable
{
    private double DisplayWidth { get; set; }
    private double DisplayHeight { get; set; }
    private (RectF Upper, Rect Lower) Bounds { get; set; }
    private List<RectF> Obstacles { get; set; }
    private RectF Player { get; set; }
    public int Score { get; set; }

    public GameDrawable()
    {
        // Get Display Width and Display Height
        DisplayWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
        DisplayHeight = (DeviceDisplay.MainDisplayInfo.Height - 100) / DeviceDisplay.MainDisplayInfo.Density;

        // Set terrain elements
        Bounds = (new RectF(0, 0, (float)DisplayWidth, 20), new RectF(0, (float)DisplayHeight - 20, (float)DisplayWidth, 20));
        Obstacles = new List<RectF>();
        // Set player size and position
        Player = new RectF((float)DisplayWidth / 2, (float)DisplayHeight / 2, 50, 50);
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // Draw the bounds
        canvas.FillColor = Colors.Green;
        canvas.FillRectangle(Bounds.Upper);
        canvas.FillRectangle(Bounds.Lower);

        // Spawn new obstacles when last Obstacle is in the middle of the screen
        if (Obstacles.Count == 0 || Obstacles.Last().X < DisplayWidth * 0.5)
        {
            // Set obstacle size
            float obstacleWidth = 100f;
            float obstacleHeight = (float)DisplayHeight * (0.2f + (float)new Random().NextDouble() * 0.6f);

            // Set obstacle position
            float obstacleX = (float)DisplayWidth;
            float obstacleY = (float)DisplayHeight - obstacleHeight;

            // Add top and bottom obstacles
            Obstacles.Add(new RectF(obstacleX, 0, obstacleWidth, obstacleY - 200));
            Obstacles.Add(new RectF(obstacleX, obstacleY, obstacleWidth, obstacleHeight));
        }

        // Update the obstacles
        for (int i = Obstacles.Count - 1; i >= 0; i--)
        {
            // Create a copy of the current obstacle because RectF is a struct
            RectF obstacle = Obstacles[i];
            // Move the obstacle to the left
            obstacle.X -= 5f;
            // Checks if the obstacle has completely moved off the screen to the left
            if (obstacle.X + obstacle.Width < 0)
            {
                Obstacles.RemoveAt(i);
            }
            else
            {
                // Assign the updated obstacle back to the list
                Obstacles[i] = obstacle;
                // Draw the obstacle
                canvas.FillRectangle(obstacle);
            }
        }

        // Update the player
        float playerHeight = (Player.Y + 5) % (float)DisplayHeight;
        Player = new RectF(Player.X, playerHeight, 50, 50);
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 10;
        canvas.DrawRectangle(Player);

        // Draw the score
        canvas.FontColor = Colors.White;
        canvas.FontSize = 50;
        canvas.DrawString($"{AppResources.Score}: {Score}", 25, 25, 1000, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    }
}