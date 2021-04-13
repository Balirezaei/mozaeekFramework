using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Domain;

namespace MozaeekCore.ApplicationService.Query
{
    public class GetAllLabelParentQueryHandler : IBaseAsyncQueryHandler<LabelFilterContract, List<LabelGrid>>
    {
        private readonly IGenericRepository<Label> _repository;

        public GetAllLabelParentQueryHandler(IGenericRepository<Label> repository)
        {
            _repository = repository;
        }
        public async Task<List<LabelGrid>> HandleAsync(LabelFilterContract query)
        {
            var querys = await _repository.GetByPredicate(m => m.ParentId == null).ToListAsync();
            
            return querys.Select(m => new LabelGrid
            {
                Id = m.Id,
                Title = m.Title,
            }).ToList();
        }
    }
}