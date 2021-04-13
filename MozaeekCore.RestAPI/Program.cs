using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace MozaeekCore.RestAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
