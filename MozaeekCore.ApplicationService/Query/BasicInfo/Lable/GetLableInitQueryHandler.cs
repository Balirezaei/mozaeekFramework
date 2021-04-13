using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Domain;
using MozaeekCore.Mapper;

namespace MozaeekCore.ApplicationService.Query
{
    public class GetLabelInitQueryHandler : IBaseAsyncQueryHandler<Nothing, InitLabelDto>
    {
        private readonly IGenericRepository<Label> _repository;

        public GetLabelInitQueryHandler(IGenericRepository<Label> repository)
        {
            _repository = repository;
        }
        public async Task<InitLabelDto> HandleAsync(Nothing query)
        {
            var res = (await _repository.GetAll().Select(m => BasicInfoProfile.GetLabelDtoNoParent(m)).ToListAsync());
            return new InitLabelDto()
            {
                Labels = res
            };
        }
    }
}