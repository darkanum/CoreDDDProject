using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Infrastructure.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DDD.UI.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost (args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ClientContext>();
                    DbInitializer.Initialize(context);
                }catch ( Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Error on seeding context");
                }
            }

            host.Run();
            //CreateHostBuilder(args).Build().Run();
        }

        private static IWebHost BuildWebHost(string[] args) =>
        
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
