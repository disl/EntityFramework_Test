using EntityFramework_Test.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using WpfCoreEF.Views;

namespace WpfCoreEF
{
    https://stackoverflow.com/questions/58715185/wpf-and-entityframeworkcore-adding-migration-gives-no-database-provider-has-b

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }
        /// <summary>
        /// Hold the built Host for starting and stopping
        /// </summary>
        private readonly IHost AppHost;

         public App()
    {
        // Create Application host
        AppHost = CreateHostBuilder(new string[] { }).Build();
    }

        /// <summary>
        /// Necessary for EF core to be able to find and construct
        /// the DB context.
        /// </summary>
        /// 
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                // Configure Application services
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context, services);
                });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder();

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<CoursesWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            var connection_str = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            services.AddDbContext<SchoolContext>(options => options.UseSqlServer(connection_str));
            services.AddTransient(typeof(CoursesWindow));
            services.AddTransient(typeof(MainWindow));

           
        }

        
    }
}
