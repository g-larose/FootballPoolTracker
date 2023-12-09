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
            _navigator.CurrentViewModel = new MatchupsViewModel(_footballDataProvider);
            OpenCommand = new NavigateCommand<MatchupsViewModel>(_navigator, () => new MatchupsViewModel(_footballDataProvider));
            TestCommand = new RelayCommand(Test);
        }
        
        private void OnSelectedViewModelChanged()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
        }

        private void Test()
        {
            var data = _footballDataProvider.GetWeeklyMatchups(0, 0);
            for (int i = 0; i < data.Count(); i+= 2)
            {
               
            }
        }
    }
}
