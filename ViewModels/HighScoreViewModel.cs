using CommunityToolkit.Mvvm.ComponentModel;
using Flappy_Miau.Models;
using System.Collections.ObjectModel;

namespace Flappy_Miau.ViewModels;

public partial class HighScoreViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Score> highScores;

    public HighScoreViewModel()
    {
        HighScores = new ObservableCollection<Score>();
        CreateDummyScores(100);
    }

    public void CreateDummyScores(int count)
    {
        for (int i = 0; i < count; i++)
        {
            // Random value between 0 and 10000
            int value = new Random().Next(0, 10000);
            SaveScore(value);
        }
    }

    public void SaveScore(int value)
    {
        // Add new score to the list and sort it
        HighScores.Add(new Score(DateTime.Now, value));
        HighScores = new ObservableCollection<Score>(HighScores.OrderByDescending(x => x.Value));
    }
}