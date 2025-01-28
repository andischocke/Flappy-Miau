using SQLite;

namespace Flappy_Miau.Models;

public class Score
{
    [PrimaryKey]
    public DateTime Date { get; set; }
    public int Value { get; set; }

    public Score() { }

    public Score(DateTime date, int value)
    {
        Date = date;
        Value = value;
    }
}