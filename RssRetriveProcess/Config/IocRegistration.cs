using JudgeInquiryBot.WindowsService.Job;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RssRetriveProcess.Context;
using RssRetriveProcess.Facade;
using RssRetriveProcess.Service;

namespace RssRetriveProcess.Config
{
    public class IocRegistration
    {
        private readonly IConfigurationRoot _configuration;

        public IocRegistration(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            
           

            services.AddDbContext<FeedContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("FeedContext"),
                    builder => builder.MigrationsAssembly("RssRetriveProcess.EF")), ServiceLifetime.Transient);



            services.AddScoped<LogManagement.ILogger, LogManagement.SeiLogManager>();
           
            services.AddScoped<IRSSManager, RSSManager>();

            services.AddScoped<IRssRetriveFacade, RssRetriveFacade>();

            services.AddScoped<OrchestratorConfiguration>();
            return services;
        }

        
    }
}