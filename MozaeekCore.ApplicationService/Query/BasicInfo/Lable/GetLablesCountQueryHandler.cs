using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Domain;

namespace MozaeekCore.ApplicationService.Query
{
    public class GetLabelsCountQueryHandler : IBaseAsyncQueryHandler<Nothing, LabelTotalCount>
    {
        private readonly IGenericRepository<Label> _repository;


        public GetLabelsCountQueryHandler(IGenericRepository<Label> repository)
        {
            _repository = repository;
        }

        public async Task<LabelTotalCount> HandleAsync(Nothing query)
        {
            long count = await _repository.GetByPredicate(m => m.ParentId == null).CountAsync();
            return new LabelTotalCount(count);
        }
    }
}