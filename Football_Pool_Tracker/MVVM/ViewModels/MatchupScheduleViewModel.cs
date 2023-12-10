using System.Windows.Input;
using Football_Pool_Tracker.Application.Common;
using Football_Pool_Tracker.Application.Interface;
using Football_Pool_Tracker.Domain.Entities;
using Football_Pool_Tracker.MVVM.Commands;

namespace Football_Pool_Tracker.UI.MVVM.ViewModels;

public class MatchupScheduleViewModel : ViewModelBase
{
    private readonly IFootballDataProvider _footballDataProvider;
    private List<Matchup> _matchups;
    public List<Matchup> Matchups
    {
        get => _matchups;
        set => OnPropertyChanged(ref _matchups, value);
    }

    private string _year;
    public string Year
    {
        get => _year;
        set => OnPropertyChanged(ref _year, value);
    }
    
    private string _week;
    public string Week
    {
        get => _week;
        set => OnPropertyChanged(ref _week, value);
    }

    private string _gameDate;

    public string GameDate
    {
        get => _gameDate;
        set => OnPropertyChanged(ref _gameDate, value);
    }
    
    public ICommand SearchMatchupsCommand { get; }
    
    public MatchupScheduleViewModel(IFootballDataProvider footballDataProvider)
    {
        _footballDataProvider = footballDataProvider;
        SearchMatchupsCommand = new RelayCommand(SearchMatchups);
    }

    private void SearchMatchups()
    {
        var year = uint.Parse(Year);
        var week = uint.Parse(Week);
        Matchups = _footballDataProvider.GetWeeklyMatchups(year, week);
    }
}