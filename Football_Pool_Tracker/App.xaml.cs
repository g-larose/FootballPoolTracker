using Football_Pool_Tracker.Application.Interface;
using Football_Pool_Tracker.Infrastructure.Provider;
using Football_Pool_Tracker.UI.MVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Football_Pool_Tracker.Application.Common.Navigation;

namespace Football_Pool_Tracker
{
    public partial class App
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<AppViewModel>();
                services.AddSingleton<IFootballDataProvider, FootballDataProvider>();
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<IHtmlDataProvider, HtmlDataProvider>();
                services.AddSingleton<MainWindow>(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<AppViewModel>()
                });
                services.AddSingleton<MatchupsViewModel>();
            }).Build();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }
    }

}
