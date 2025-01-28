using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Flappy_Miau.Models;
using Flappy_Miau.Services;
using System.Collections.ObjectModel;

namespace Flappy_Miau.ViewModels;

public partial class HighScoreViewModel : ObservableObject
{
    private Database Database { get; set; }

    [ObservableProperty]
    private ObservableCollection<Score> highScores;

    public HighScoreViewModel(Database database)
    {
        Database = database;
        HighScores = new ObservableCollection<Score>();
        ReadScoresCommand.Execute(null);
    }

    [RelayCommand]
    private async Task ReadScores()
    {
        List<Score> scores = await Database.ReadTable<Score>();
        HighScores = new ObservableCollection<Score>(scores.OrderByDescending(x => x.Value));
    }
}