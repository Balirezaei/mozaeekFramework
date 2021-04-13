using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Domain;
using MozaeekCore.Exceptions;
using MozaeekCore.Mapper;

namespace MozaeekCore.ApplicationService.Query
{
    public class GetLabelByIdQueryHandler : IBaseAsyncQueryHandler<FindByKey, LabelDto>
    {
        private readonly IGenericRepository<Label> _repository;

        public GetLabelByIdQueryHandler(IGenericRepository<Label> repository)
        {
            _repository = repository;
        }
        public async Task<LabelDto> HandleAsync(FindByKey query)
        {
            var res = await _repository.Find(query.Id);
            if (res == null)
            {
                throw new UserFriendlyException("اطلاعات یافت نشد");
            }
            return res.GetLabelDto();
        }
    }
}