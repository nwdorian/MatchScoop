namespace MatchScoop.Console.Models;

public class Match
{
    public Match(Team home, Team away)
    {
        ArgumentNullException.ThrowIfNull(home);
        ArgumentNullException.ThrowIfNull(away);

        Home = home;
        Away = away;
    }

    public Team Home { get; private set; }
    public Team Away { get; private set; }
}
