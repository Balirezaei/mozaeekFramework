using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Domain;

namespace MozaeekCore.ApplicationService.Query
{
    public class GetAllLabelChildrenQueryHandler : IBaseAsyncQueryHandler<FindByKey, List<LabelGrid>>
    {
        private readonly IGenericRepository<Label> _repository;

        public GetAllLabelChildrenQueryHandler(IGenericRepository<Label> repository)
        {
            _repository = repository;
        }

        public async Task<List<LabelGrid>> HandleAsync(FindByKey query)
        {
            var querys =  _repository.GetByPredicate(m => m.ParentId == query.Id);
            return querys.Select(m => new LabelGrid
            {
                Id = m.Id,
                Title = m.Title,
            }).ToList();
        }
    }
}