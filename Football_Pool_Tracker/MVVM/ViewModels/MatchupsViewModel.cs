using Football_Pool_Tracker.Application.Common;
using Football_Pool_Tracker.Application.Interface;
using Football_Pool_Tracker.Domain.Entities;

namespace Football_Pool_Tracker.UI.MVVM.ViewModels;

public class MatchupsViewModel : ViewModelBase
{
    private List<Matchup> _matchups;
    public List<Matchup> Matchups
    {
        get => _matchups;
        set => OnPropertyChanged(ref _matchups, value);
    }

    public MatchupsViewModel(IFootballDataProvider footballDataProvider)
    {
        Matchups = footballDataProvider.GetWeeklyMatchups(0, 0);
    }
}