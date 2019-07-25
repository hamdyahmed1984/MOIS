using ClientApp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Persistence.EntityFrameworkDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Application.Security.Hashing;
using Application.Interfaces;
using Microsoft.AspNetCore;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace FunctionalTests
{
    public class CustomWebApplicationFactory<TStartup>: WebApplicationFactory<TStartup> where TStartup: class
    {
        //This overriden method is required in case we use custom Startup class
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder<TStartup>(null);
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider
                var internalServiceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                // Add a database context (MoisContext) using an in-memory database for testing.
                services.AddDbContext<MoisContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(internalServiceProvider);
                });
                services.AddScoped<IPasswordHasher, PasswordHasher>();
                //We have to add the appsettings.json file in the test project and make it copy to output directory to load configs from the file
                var projectDir = Directory.GetCurrentDirectory();
                var configPath = Path.Combine(projectDir, "appsettings.json");
                builder.ConfigureAppConfiguration((context, conf) =>
                {
                    conf.AddJsonFile(configPath);
                });

                //Build the service provider
                var serviceProvider = services.BuildServiceProvider();
                // Create a scope to obtain a reference to the database context
                using(var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<MoisContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();
                    //var x = scopedServices.GetService<ITokenVerificationService>();
                    var passwordHasher = scopedServices.GetRequiredService<IPasswordHasher>();
                    db.Database.EnsureCreated();

                    try
                    {
                        //Seed data
                        DatabaseSeed.SeedAsync(db, passwordHasher);
                    }
                    catch(Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred during seeding data. Error: {ex.Message}");
                    }
                }
            });
        }
    }
}
