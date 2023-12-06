using Football_Pool_Tracker.Application.Interface;

namespace Football_Pool_Tracker.Application.Common.Navigation;

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