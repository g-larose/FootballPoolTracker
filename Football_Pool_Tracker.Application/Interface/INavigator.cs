using Football_Pool_Tracker.UI.MVVM.ViewModels;
namespace Football_Pool_Tracker.Application.Interface;

public interface INavigator
{
    public event Action CurrentViewModelChanged;
    public ViewModelBase CurrentViewModel { get; set; }
}