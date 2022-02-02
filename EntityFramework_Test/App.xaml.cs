using EntityFramework_Test.Data;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EntityFramework_Test
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            
        }

        //private static void CreateDbIfNotExists()
        //{
        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;
        //        try
        //        {
        //            var context = services.GetRequiredService<SchoolContext>();
        //            DbInitializer.Initialize(context);
        //        }
        //        catch (Exception ex)
        //        {
        //            //var logger = services.GetRequiredService<ILogger<Program>>();
        //            //logger.LogError(ex, "An error occurred creating the DB.");
        //        }
        //    }
        //}

    }
}
