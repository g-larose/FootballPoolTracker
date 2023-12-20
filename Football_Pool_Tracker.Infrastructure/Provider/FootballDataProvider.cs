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
            HtmlNodeCollection matchupNodes = _htmlDataProvider.GetNodes(year, week, ".//div[@class='lngame']/table/tbody/tr");
            var gameDates = _htmlDataProvider.GetNodes(year, week, ".//div[@class='lngame']/table/thead/tr/th");
            var id = 0;
            for (int i = 0; i < matchupNodes.Count; i+= 2)
            {
                //TODO: check for null here before we try to access the node.
                //node may be null and will throw an exception.
                var homeNode            = ParseTeamData(matchupNodes[i + 1]);
                var awayNode            = ParseTeamData(matchupNodes[i]);
                var awayScores = new string[5];
                var homeScores = new string[5];
                
                if (matchupNodes[i + 1].ChildNodes[1].HasChildNodes && matchupNodes[i + 1].ChildNodes.Count > 5)
                {
                    homeScores = ParseScores(matchupNodes[i + 1]);
                }
                else
                {
                    homeScores = ParseScores(matchupNodes[i + 1]);
                }
                if (matchupNodes[i].ChildNodes[1].HasChildNodes && matchupNodes[i].ChildNodes.Count > 5)
                {
                    awayScores = ParseScores(matchupNodes[i]);
                }
                else
                {
                    awayScores = ParseScores(matchupNodes[i]);
                }

                #region CREATE MATCHUP
                var matchup = new Matchup()
                                {
                                    //GameDate   = DateTime.Parse(gameDate).ToShortDateString(),
                                    Id = id += 1,
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
                                        Scores           = awayScores,
                                    },
                                    HomeTeam = new Team()
                                    {
                                        Name            = homeNode.Name,
                                        Record          = homeNode.Record,
                                        Abbreviation    = homeNode.Abbreviation,
                                        Division        = homeNode.Division,
                                        LogoUrl         = homeNode.LogoUrl,
                                        IsWinner        = false,
                                        Scores          = homeScores,
                                    }
                                };

                #endregion
                
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
                LogoUrl      = logoUrl,
            };
            return team;
        }

        private string[] ParseScores(HtmlNode node)
        {
            string[] scores = new string[5];
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                if (node.ChildNodes.Count > 5)
                {
                    scores[0] = node.ChildNodes[3].InnerText;
                    scores[1] = node.ChildNodes[4].InnerText;
                    scores[2] = node.ChildNodes[5].InnerText;
                    scores[3] = node.ChildNodes[6].InnerText;
                    scores[4] = node.ChildNodes[7].InnerText;
                }
                else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        scores[i] = "--";
                    }
                }
            }
            return scores;
        }
    }
}
