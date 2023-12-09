using Football_Pool_Tracker.Application.Interface;
using Football_Pool_Tracker.Domain.Entities;
using Football_Pool_Tracker.Infrastructure.Extensions;
using HtmlAgilityPack;

namespace Football_Pool_Tracker.Infrastructure.Provider
{
    public class FootballDataProvider : IFootballDataProvider
    {
        private readonly IHtmlDataProvider _htmlDataProvider; 
        public FootballDataProvider(IHtmlDataProvider htmlDataProvider)
        {
            _htmlDataProvider = htmlDataProvider;
        }
        public List<Matchup> GetWeeklyMatchups(uint year = 0, uint week = 0, CancellationToken ct = default)
        {
            var matchups = new List<Matchup>();
            var matchupNodes = _htmlDataProvider.GetNodes(year, week, ".//div[@class='lngame']/table/tbody/tr");

            for (int i = 0; i < matchupNodes.Count; i+= 2)
            {
                //TODO: check for null here before we try to access the node.
                //node may be null and will throw an exception.
                var homeNode            = ParseTeamData(matchupNodes[i + 1]);
                var awayNode            = ParseTeamData(matchupNodes[i]);
                
                var matchup = new Matchup()
                {
                    GameDate   = DateTime.Today,
                    GameType   = GameType.REGULAR,
                    Year       = year, 
                    Week       = week,
                    AwayTeam   = new Team()
                    {
                        Name             = awayNode.Name,
                        Record           = awayNode.Record,
                        Abbreviation     = awayNode.Abbreviation,
                        Division         = awayNode.Division,
                        LogoUrl          = awayNode.LogoUrl,
                        IsWinner         = false,
                    },
                    HomeTeam = new Team()
                    {
                        Name            = homeNode.Name,
                        Record          = homeNode.Record,
                        Abbreviation    = homeNode.Abbreviation,
                        Division        = homeNode.Division,
                        LogoUrl         = homeNode.LogoUrl,
                        IsWinner        = false,
                    }
                };
                matchups.Add(matchup);
            }
            return matchups;
        }
        private Team ParseTeamData(HtmlNode node)
        {
            var teamName        = node.ChildNodes[1].InnerText.Split('(')[0].Trim();
            var abbr            = teamName.ToTeamAbbr();
            var division        = teamName.ToDivision();
            var teamRecordIndex = node.ChildNodes[1].InnerText.LastIndexOf('(');
            var teamRecord      = node.ChildNodes[1].InnerText.Substring(teamRecordIndex - 1);
            var logoUrl         = $"/Assets/Logo/{abbr}.png";

            var team = new Team()
            {
                Name         = teamName,
                Abbreviation = abbr,
                Record       = teamRecord,
                Division     = division,
                IsWinner     = false,
                LogoUrl      = logoUrl
            };
            return team;
        }
    }
}
