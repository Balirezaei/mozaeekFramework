using System.Threading.Tasks;

namespace MozaeekCore.Core.QueryHandler
{
    public interface IBaseAsyncQueryHandler<TQuery, TResult> //where TQuery : Query
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}