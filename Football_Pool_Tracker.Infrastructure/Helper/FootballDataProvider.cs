using Football_Pool_Tracker.Application.Interface;
using Football_Pool_Tracker.Domain.Entities;
using Football_Pool_Tracker.Infrastructure.Extensions;

namespace Football_Pool_Tracker.Infrastructure.Helper
{
    public class FootballDataProvider : IFootballDataProvider
    {
        private readonly IHtmlDataProvider _htmlDataProvider; 
        public FootballDataProvider(IHtmlDataProvider htmlDataProvider)
        {
            _htmlDataProvider = htmlDataProvider;
        }
        public List<Matchup> GetWeeklyMatchups(string year, string week, CancellationToken ct = default)
        {
            var matchups = new List<Matchup>();
            var matchupNodes = _htmlDataProvider.GetNodes(year, week, ".//div[@class='lngame']/table/tbody/tr");

            for (int i = 0; i < matchupNodes.Count; i+= 2)
            {
                //TODO: check for null here before we try to access the node.
                //node may be null and will throw an exception.
                var homeNode            = matchupNodes[i + 1];
                var awayNode            = matchupNodes[i];
                
                var awayTeamName        = awayNode.ChildNodes[1].InnerText.Split('(')[0].Trim();
                var awayAbbr = awayTeamName.ToTeamAbbr();
                var awayTeamRecordIndex = awayNode.ChildNodes[1].InnerText.LastIndexOf('(');
                var awayTeamRecord      = awayNode.ChildNodes[1].InnerText.Substring(awayTeamRecordIndex - 1);
                
                var homeTeamName        = homeNode.ChildNodes[1].InnerText.Split('(')[0].Trim();
                var homeAbbr = homeTeamName.ToTeamAbbr();
                var homeTeamRecordIndex = homeNode.ChildNodes[1].InnerText.LastIndexOf('(');
                var homeTeamRecord      = homeNode.ChildNodes[1].InnerText.Substring(homeTeamRecordIndex - 1);
                var matchup = new Matchup()
                {
                    GameDate = DateTime.Today,
                    GameType = GameType.REGULAR,
                    Year = int.Parse(year),
                    Week = int.Parse(week),
                    AwayTeam = new Team()
                    {
                        Name = awayTeamName,
                        //TODO: here we need to abstract a method to convert the team name into it's abbreviation (not written yet).
                        Record = awayTeamRecord,
                        Abbr = awayAbbr,
                        Division = "NFC",
                        LogoUrl ="/Assets/Logo/TB.png",
                        IsWinner = false,
                        //TODO: here we need to abstract a method to fetch the logo url from the team name.
                    },
                    HomeTeam = new Team()
                    {
                        Name = homeTeamName,
                        //TODO: here we need to abstract a method to convert the team name into it's abbreviation (not written yet).
                        Record = homeTeamRecord,
                        Abbr = homeAbbr,
                        Division = "NFC",
                        LogoUrl ="/Assets/Logo/DAL.png",
                        IsWinner = false,
                        //TODO: here we need to abstract a method to fetch the logo url from the team name.
                    }
                };
                
                matchups.Add(matchup);
            }
            
            return matchups;
        }
    }
}
