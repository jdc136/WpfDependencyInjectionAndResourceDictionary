using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectB;
using ProjectC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectA
{
    public partial class App : Application
    {
        private readonly IHost _appHost;

        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            _appHost = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((hostContext, configuration) =>
                {
                    configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<ColorSettings>(hostContext.Configuration.GetSection(nameof(ColorSettings)));

                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton(serviceProvider => new MainWindow()
                    {
                        DataContext = serviceProvider.GetRequiredService<MainViewModel>()
                    });


                    if (true /*a condition would go here, but currently irrelevant*/)
                    {
                        services.AddSingleton<IViewModel, MyDisplayViewModel>();
                    }

                })
                .Build();
        }



        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow startupWindow = _appHost.Services.GetRequiredService<MainWindow>();
            startupWindow.Show();
        }


        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Debug.WriteLine(((Exception)e.ExceptionObject).Message);
        }

    }
}
