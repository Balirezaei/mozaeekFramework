using System;
using System.Threading.Tasks;

namespace MozaeekCore.Core.QueryHandler
{
    public class QueryProcessor : IQueryProcessor
    {
        private readonly IServiceProvider services;

        public QueryProcessor(IServiceProvider services)
        {
            this.services = services;
        }

        public TResult Process<TQuery, TResult>(TQuery query)
        {
            var handler = (IBaseQueryHandler<TQuery, TResult>)services.GetService(typeof(IBaseQueryHandler<TQuery, TResult>));
            return handler.Handle(query);
        }

        public bool Check<TQuery, TResult>(TQuery query)
        {
            var handler = (IBaseQueryHandler<TQuery, TResult>)services.GetService(typeof(IBaseQueryHandler<TQuery, TResult>));
            return Convert.ToBoolean(handler);
        }

        public Task<TResult> ProcessAsync<TQuery, TResult>(TQuery query)
        {
            var handler = (IBaseAsyncQueryHandler<TQuery, TResult>)services.GetService(typeof(IBaseAsyncQueryHandler<TQuery, TResult>));
            return handler.HandleAsync(query);
        }
    }
}