using DTORestApiExample.Application.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using System.Windows;

namespace DTORestApiExample.Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    public static class Constants
    {
        public const string BaseUri = "https://localhost:7177/";
    }

    public partial class App : System.Windows.Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateDefaultBuilder().Build();
        }

        public IHostBuilder CreateDefaultBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                       .ConfigureServices((context, services) =>
                       {
                           services.AddSingleton<MainWindow>();
                           services.AddSingleton<MainViewModel>();
                           services.AddScoped<AddUserViewModel>();
                           services.AddScoped<UsersViewModel>();
                           services.AddSingleton<HttpClient>(s => new HttpClient());
                       });
        }

        protected override void OnStartup(StartupEventArgs e)
        {  
            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }
    }
}
