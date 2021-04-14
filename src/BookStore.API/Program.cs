using System;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using BookStore.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var appContext = services.GetRequiredService<AppDbContext>();
                    appContext.Database.EnsureCreated();    // check if db is created
                    appContext.Database.Migrate();  // run pending migrations
                    SeedData.Initialize(services);  // seed data

                    var IdentityContext = services.GetRequiredService<IdentityDbContext>();
                    IdentityContext.Database.EnsureCreated();   // check if db is created
                    IdentityContext.Database.Migrate(); // run pending migrations
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run(); // run application
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory()) // use autofac instead of default DI
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseStartup<Startup>()
                    .ConfigureLogging(
                        logging =>
                        {
                            logging.ClearProviders();
                            logging.AddConsole();
                        });
                });
    }
}
