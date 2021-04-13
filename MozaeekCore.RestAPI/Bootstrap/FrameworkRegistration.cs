using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MozaeekCore.Common.Crypto;
using MozaeekCore.Core;
using MozaeekCore.Core.CommandBus;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Domain;
using MozaeekCore.LogManagement;
using MozaeekCore.Persistense.EF;
using MozaeekCore.Persistense.EF.Repository;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace MozaeekCore.RestAPI.Bootstrap
{
    public static class FrameworkRegistration
    {
        public static IServiceCollection AddFrameworkServices(this IServiceCollection services)
        {
            services.AddSingleton<ICommandBus, CommandBus>();
            services.AddScoped<IQueryProcessor, QueryProcessor>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped( typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            services.AddScoped<ILogManagement, DoLogManagement>();
            services.AddScoped(typeof(LoggingHandlerDecorator<,>));
            services.AddScoped(typeof(CatchErrorCommandHandlerDecorator<,>));
            services.AddScoped(typeof(AuthorizeCommandHandlerDecorator<,>));
            services.AddScoped(typeof(AuthorizeCommandAsyncHandlerDecorator<,>));
            
            services.AddScoped<IPasswordService, PasswordService>();
            return services;
        }
    }
}