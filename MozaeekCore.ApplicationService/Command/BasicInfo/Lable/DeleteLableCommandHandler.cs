using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.Domain;

namespace MozaeekCore.ApplicationService.Command
{
    public class DeleteLabelCommandHandler : IBaseAsyncCommandHandler<DeleteLabelCommand, DeleteCommandResult>
    {
        private readonly IGenericRepository<Label> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLabelCommandHandler(IGenericRepository<Label> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteCommandResult> HandleAsync(DeleteLabelCommand cmd)
        {
            var Label = await _repository.Find(cmd.Id);
            _repository.Delete(Label);

            await _unitOfWork.CommitAsync();


            return new DeleteCommandResult()
            {
            };
        }
    }
}