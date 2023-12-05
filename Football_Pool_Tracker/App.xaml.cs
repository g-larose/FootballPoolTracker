using Football_Pool_Tracker.Application.Interface;
using Football_Pool_Tracker.Infrastructure.Helper;
using Football_Pool_Tracker.UI.MVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Football_Pool_Tracker
{
    public partial class App
    {
        private IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<IFootballDataProvider, FootballDataProvider>();
                services.AddSingleton<IHtmlDataProvider, HtmlDataProvider>();
                services.AddSingleton<MainWindow>(s => new MainWindow()
                {
                    DataContext = new AppViewModel()
                });
            }).Build();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }
    }

}
