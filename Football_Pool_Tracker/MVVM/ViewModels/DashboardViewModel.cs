using Football_Pool_Tracker.Application.Common;
using Football_Pool_Tracker.Application.Interface;

namespace Football_Pool_Tracker.UI.MVVM.ViewModels;

public class DashboardViewModel : ViewModelBase
{
    private readonly INavigator _navigator;
    public ViewModelBase? SelectedViewModel => _navigator.CurrentViewModel;

    public DashboardViewModel(INavigator navigator)
    {
        _navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
        _navigator.CurrentViewModelChanged += OnSelectedViewModelChanged;
    }

    private void OnSelectedViewModelChanged()
    {
        OnPropertyChanged(nameof(SelectedViewModel));
    }
}