using System.Windows.Input;
using Football_Pool_Tracker.Application.Common;
using Football_Pool_Tracker.Application.Interface;
using Football_Pool_Tracker.MVVM.Commands;

namespace Football_Pool_Tracker.UI.MVVM.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IFootballDataProvider _footballDataProvider;
        public ViewModelBase SelectedViewModel => _navigator.CurrentViewModel;
        public ICommand OpenCommand { get; }
        public ICommand TestCommand { get; }
        public AppViewModel(INavigator navigator, IFootballDataProvider footballDataProvider)
        {
            _navigator = navigator;
            _footballDataProvider = footballDataProvider;
            _navigator.CurrentViewModelChanged += OnSelectedViewModelChanged;
            _navigator.CurrentViewModel = new MatchupScheduleViewModel(_footballDataProvider);
            OpenCommand = new NavigateCommand<MatchupsViewModel>(_navigator, () => new MatchupsViewModel(_footballDataProvider));
  
        }
        private void OnSelectedViewModelChanged()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
        }
    }
}
