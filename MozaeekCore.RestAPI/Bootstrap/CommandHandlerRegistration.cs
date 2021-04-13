using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MozaeekCore.ApplicationService;
using MozaeekCore.ApplicationService.Command;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.Core.Commands;

namespace MozaeekCore.RestAPI.Bootstrap
{
    public static class CommandHandlerRegistration
    {
        public static IServiceCollection AddCommandHandlerServices(this IServiceCollection services)
        {
            typeof(CreateLabelCommandHandler)
                .Assembly
                .GetTypes()
                .Where(m => m.GetTypeInfo().ImplementedInterfaces.Where(z => z.IsGenericType)
                    .Any(z => z.GetGenericTypeDefinition() == typeof(IBaseAsyncCommandHandler<,>))).ToList().ForEach(assignedTypes =>
                {
                    try
                    {
                        var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IBaseAsyncCommandHandler<,>));
                        services.AddScoped(serviceType, assignedTypes);
                    }
                    catch (System.Exception e)
                    {

                    }
                });



            return services;
        }
    }
}