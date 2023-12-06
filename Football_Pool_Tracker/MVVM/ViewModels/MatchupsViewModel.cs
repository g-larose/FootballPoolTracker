using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Printing;
using System.Runtime.InteropServices.JavaScript;
using Football_Pool_Tracker.Domain.Entities;

namespace Football_Pool_Tracker.UI.MVVM.ViewModels;

public class MatchupsViewModel : ViewModelBase
{
    private ObservableCollection<Matchup> _matchups;
    public ObservableCollection<Matchup> Matchups
    {
        get => _matchups;
        set => OnPropertyChanged(ref _matchups, value);
    }

    public MatchupsViewModel()
    {
        Matchups = LoadMatchups();
    }

    private ObservableCollection<Matchup> LoadMatchups()
    {
        var matchups = new ObservableCollection<Matchup>();
        for (int i = 0; i < 12; i++)
        {
           var matchup = new Matchup()
                   {
                      AwayTeam = new Team()
                      {
                          Name = "TampaBay",
                          Abbr = "TB",
                          IsWinner = true,
                          LogoUrl = "/Assets/Logo/TB.png",
                          Record = "(1-1-0"
                      },
                      HomeTeam = new Team()
                      {
                          Name = "Dallas Cowboys",
                          Abbr = "Dal",
                          IsWinner = false,
                          LogoUrl = "/Assets/Logo/DAL.png",
                          Record = "(1-1-0"
                      },
                      AwayTeamScore = 21,
                      HomeTeamScore = 6,
                      GameDate = DateTime.Today,
                      GameType = GameType.REGULAR,
                      Week = 2, 
                      Year = 2023,
                      Id = i
                   }; 
           matchups.Add(matchup);
        }
        return matchups;
    }
}