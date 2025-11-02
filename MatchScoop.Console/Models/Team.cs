namespace MatchScoop.Console.Models;

public class Team
{
    public Team(string name, int score)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nameof(name));

        Name = name;
        Score = score;
    }

    public string Name { get; private set; }
    public int Score { get; private set; }
}
