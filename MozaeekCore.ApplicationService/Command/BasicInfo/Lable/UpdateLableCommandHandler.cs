using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.Domain;

namespace MozaeekCore.ApplicationService.Command
{
    public class UpdateLabelCommandHandler : IBaseAsyncCommandHandler<UpdateLabelCommand, UpdateLabelCommandResult>
    {
        private readonly IGenericRepository<Label> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLabelCommandHandler(IGenericRepository<Label> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateLabelCommandResult> HandleAsync(UpdateLabelCommand cmd)
        {
            var label = await _repository.Find(cmd.Id);
            label.UpdateTitle(cmd.Title);
            _repository.Update(label);

            await _unitOfWork.CommitAsync();

            return new UpdateLabelCommandResult()
            {
                Id = label.Id,
                ParentId = label.ParentId,
                Title = label.Title
            };
        }
    }
}