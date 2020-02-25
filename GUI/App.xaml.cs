using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GUI.Model;
using GUI.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {            
            services.AddSingleton<MainWindow>();
            services.AddSingleton<SomethingAPIClient>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            var api = _serviceProvider.GetService<SomethingAPIClient>();

            mainWindow.DataContext = new MainWindowViewModel(api);

            mainWindow.Show();
        }
    }
}
