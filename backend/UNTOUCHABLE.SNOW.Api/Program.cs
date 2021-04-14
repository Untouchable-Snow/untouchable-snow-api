using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Untouchable.Snow.Data;

namespace UNTOUCHABLE.SNOW.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
        	var host = CreateHostBuilder(args).Build();
            CreateDBIfNotExists(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void CreateDBIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();

                try
                {
                    var context = services.GetRequiredService<StoreContext>();
                    context.Database.EnsureCreated();
                    DBInitializer.Initialize(context, logger);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error occurred creating the database.");
                }
            }
        }
    }
}
