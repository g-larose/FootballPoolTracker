using Football_Pool_Tracker.Application.Interface;
using Football_Pool_Tracker.Domain.Entities;

namespace Football_Pool_Tracker.Infrastructure.Provider;

public class FootballPlayerProvider : IFootballPlayerProvider
{
    public List<NFLPlayer> GetCurrentNFLPlayers()
    {
        //we look in the db for the players if found return them all.
        //if not found we reach out to the website for the info.
        throw new NotImplementedException();
    }
}