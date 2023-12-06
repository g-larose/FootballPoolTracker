using Football_Pool_Tracker.Application.Interface;
using Football_Pool_Tracker.UI.MVVM.ViewModels;

namespace Football_Pool_Tracker.MVVM.Navigation;

public class Navigator : INavigator
{
    public event Action? CurrentViewModelChanged;
    private ViewModelBase? _currentViewModel;
    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }
    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
}