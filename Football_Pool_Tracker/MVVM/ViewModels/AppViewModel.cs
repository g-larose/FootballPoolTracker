using System.Windows.Input;
using Football_Pool_Tracker.Application.Common;
using Football_Pool_Tracker.Application.Interface;
using Football_Pool_Tracker.MVVM.Commands;

namespace Football_Pool_Tracker.UI.MVVM.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        public ViewModelBase SelectedViewModel => _navigator.CurrentViewModel;
        public ICommand OpenCommand { get; }

        public AppViewModel(INavigator navigator)
        {
            _navigator = navigator;
            _navigator.CurrentViewModelChanged += OnSelectedViewModelChanged;
            OpenCommand = new NavigateCommand<MatchupsViewModel>(_navigator, () => new MatchupsViewModel());
        }
        
        private void OnSelectedViewModelChanged()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
        }
    }
}
