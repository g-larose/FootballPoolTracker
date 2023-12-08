using Football_Pool_Tracker.Application.Interface;
using Football_Pool_Tracker.Domain.Entities;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var homeNode            = matchupNodes[i + 1];
                var awayNode            = matchupNodes[i];
                
                var awayTeamName        = awayNode.ChildNodes[1].InnerText.Split('(')[0];
                var awayTeamRecordIndex = awayNode.ChildNodes[1].InnerText.LastIndexOf('(');
                var awayTeamRecord      = awayNode.ChildNodes[1].InnerText.Substring(awayTeamRecordIndex - 1);
                
                var homeTeamName        = homeNode.ChildNodes[1].InnerText.Split('(')[0];
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
                        IsWinner = false,
                        //TODO: here we need to abstract a method to fetch the logo url from the team name.
                    },
                    HomeTeam = new Team()
                    {
                        Name = homeTeamName,
                        //TODO: here we need to abstract a method to convert the team name into it's abbreviation (not written yet).
                        Record = homeTeamRecord,
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
