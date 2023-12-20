using Football_Pool_Tracker.Application.Interface;
using Football_Pool_Tracker.Domain.Entities;
using HtmlAgilityPack;

namespace Football_Pool_Tracker.Infrastructure.Provider;

public class FootballPlayerProvider : IFootballPlayerProvider
{
    public List<NFLPlayer> GetCurrentNFLPlayers()
    {
        //we look in the db for the players if found return them all.
        //if not found we reach out to the website for the info.
        var baseLink = "https://www.footballdb.com/players/players.html?letter=";
        var letters = "abcdefghijklmnopqrstuvwxyz";
        var players = new List<NFLPlayer>();
        foreach (var letter in letters)
        {
            var link = $"{baseLink}{letter}";
            var web = new HtmlWeb();
            var doc = web.Load(link);
            var pageLinks = doc.DocumentNode.SelectNodes(".//div[@class='dropdown']/ul/li");
            var pageCount = pageLinks.Count;
        }
        return players;
        throw new NotImplementedException();
    }
}