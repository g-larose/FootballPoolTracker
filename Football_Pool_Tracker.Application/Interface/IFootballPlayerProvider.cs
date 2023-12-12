using Football_Pool_Tracker.Domain.Entities;
namespace Football_Pool_Tracker.Application.Interface;

public interface IFootballPlayerProvider
{
    List<NFLPlayer> GetCurrentNFLPlayers();
}