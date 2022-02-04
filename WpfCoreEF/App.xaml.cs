using AutoMapper;
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
                .ConfigureServices((context, services) => { });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder();

            Configuration = builder.Build();
            InitializeAutomapper();
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<CoursesWindow>();   //StudentWindow>();
            mainWindow.Show();
        }

        private void InitializeAutomapper()
        {

        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(typeof(CoursesWindow));
            services.AddTransient(typeof(StudentWindow));
            services.AddTransient(typeof(MainWindow));

            //services.AddDbContext<SchoolContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            //        sqlServerOptionsAction: sqlOptions =>
            //        {
            //            sqlOptions.EnableRetryOnFailure();
            //        });
            //}
            //);
        }


    }
}
