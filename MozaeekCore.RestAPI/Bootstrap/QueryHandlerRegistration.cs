using Microsoft.Extensions.DependencyInjection;
using MozaeekCore.ApplicationService.Query;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Facade.Query;
using System.Linq;
using System.Reflection;

namespace MozaeekCore.RestAPI.Bootstrap
{
    public static class QueryHandlerRegistration
    {
        public static IServiceCollection AddQueryHandlerServices(this IServiceCollection services)
        {
            services.AddScoped<ILabelQueryFacade, LabelQueryFacade>();

            typeof(GetAllLabelParentQueryHandler)
                .Assembly
                .GetTypes()
                .Where(m => m.GetTypeInfo().ImplementedInterfaces.Where(z => z.IsGenericType)
                    .Any(z => z.GetGenericTypeDefinition() == typeof(IBaseAsyncQueryHandler<,>))).ToList().ForEach(assignedTypes =>
                {
                    try
                    {
                        var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IBaseAsyncQueryHandler<,>));
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