using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using JudgeInquiryBot.WindowsService.Job;
using LogManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RssRetriveProcess.Config;
using Microsoft.Extensions.Configuration.FileExtensions;
namespace RssRetriveProcess
{
    class Program
    {
        private static IConfigurationRoot configuration;
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();

            var services = new IocRegistration(configuration).ConfigureServices();
            // Generate a provider
            var serviceProvider = services.BuildServiceProvider();

            var orchestrator = (OrchestratorConfiguration)serviceProvider.GetService(typeof(OrchestratorConfiguration));
            orchestrator.Configure();
            Console.WriteLine("Hello World!");
        }
    }
}
