using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using NGA.Core;
using NGA.Data;

namespace NGA.Api
{
    public class Program
    {
        public static ILoggerFactory loggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((category, level) => category.Contains("Command") && level == LogLevel.Information, true) });

        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            // var connectionString = configuration.GetConnectionString("DefaultConnection");

            //Data.DbContextOptions.Options = new DbContextOptionsBuilder<NGADbContext>()
            //        .UseSqlServer(connectionString)
            //        .UseLoggerFactory(loggerFactory)
            //        .Options;

            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<NGADbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration((webHostBuilderContext, configurationbuilder) =>
                        {
                            var environment = webHostBuilderContext.HostingEnvironment;
                            string pathOfCommonSettingsFile = Path.Combine(environment.ContentRootPath, "..", "Common");
                            configurationbuilder
                                    .AddJsonFile("appSettings.json", optional: true);
                            configurationbuilder.AddEnvironmentVariables();
                        })
                    .UseStartup<Startup>()
                    .Build();
    }
}
