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
        IHtmlDataProvider htmlDataProvider = new HtmlDataProvider(); //TODO this needs to be Dependency Injected via the ctor.
        public List<Matchup> GetWeeklyMatchups(string year, string week, CancellationToken ct = default)
        {
            string link = "https://www.footballdb.com/scores/index.html";
            var matchups = new List<Matchup>();
            var web = new HtmlWeb();
            var doc = web.Load(link);

            var scoreNodes = htmlDataProvider.GetNodes("//div[@class='lngame']/table/tbody/tr");


            return matchups;
        }
    }
}
