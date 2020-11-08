using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MobileStore.Context;
using MobileStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Host = CreateHostBuilder(args).Build();
            using(var Scope = Host.Services.CreateScope())
            {
                var Services = Scope.ServiceProvider;
                try
                {
                    var Context = Services.GetRequiredService<DbContextPhone>();
                    InitialData.Initialize(Context);
                }
                catch(Exception exception)
                {
                    var Logger = Services.GetRequiredService<ILogger<Program>>();
                    Logger.LogError(exception, "An error occurred seeding the DB.");
                }
            }
            Host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
