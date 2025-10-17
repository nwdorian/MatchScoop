using System.Globalization;
using CSharpFunctionalExtensions;
using HtmlAgilityPack;
using MatchScoop.Console.Models;

namespace MatchScoop.Console.Results;

public static class GetResults
{
    public static Result<IReadOnlyList<Match>> Handle(string url)
    {
        var webpage = new HtmlWeb().Load(url);
        var nodes = webpage.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[@class='game_summaries']/div/table[@class='teams']/tbody");

        if (nodes.Count == 0)
        {
            return Result.Failure<IReadOnlyList<Match>>("No matches found.");
        }

        var matches = new List<Match>();

        foreach (var node in nodes)
        {
            var homeTeamName = node.SelectSingleNode("tr[2]/td[1]").InnerText;
            var homeTeamScore = int.Parse(node.SelectSingleNode("tr[2]/td[2]").InnerText, CultureInfo.InvariantCulture);
            var awayTeamName = node.SelectSingleNode("tr[1]/td[1]").InnerText;
            var awayTeamScore = int.Parse(node.SelectSingleNode("tr[1]/td[2]").InnerText, CultureInfo.InvariantCulture);

            var match = new Match(
                new Team(homeTeamName, homeTeamScore),
                new Team(awayTeamName, awayTeamScore)
            );

            matches.Add(match);
        }

        return matches;
    }
}
