using GUI.Model;
using GUI.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GUI
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new SomethingAPIClient(Configuration.GetValue<string>("ApiUrl")));
            services.AddSingleton<MainWindowViewModel>();

            services.AddTransient<MainWindow>();
        }
    }
}
