using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Security.Hashing;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistence.EntityFrameworkDataAccess;
using Serilog;

namespace ClientApp
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        public static void Main(string[] args)
        {
            /*
             *Performance:
                By default, the file sink will flush each event written through it to disk. 
                To improve write performance, specifying buffered: true will permit the underlying stream to buffer writes.
                The Serilog.Sinks.Async package can be used to wrap the file sink and perform all disk access on a background worker thread. 
             */
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            //Serilog.Debugging.SelfLog.Enable(msg =>
            //{
            //    Debug.Print(msg);
            //    Debugger.Break();
            //});

            try
            {
                Log.Information("Application started.");
                var host = CreateWebHostBuilder(args).Build();

                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetService<MoisContext>();
                    var passwordHasher = services.GetService<IPasswordHasher>();
                    DatabaseSeed.Seed(context, passwordHasher);
                }

                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging(logging => logging.AddAzureWebAppDiagnostics())
            .UseStartup<Startup>()
            .UseSerilog();
    }
}
