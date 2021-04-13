using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.Domain;

namespace MozaeekCore.ApplicationService.Command
{
    public class CreateLabelCommandHandler : IBaseAsyncCommandHandler<CreateLabelCommand, CreateLabelCommandResult>
    {
        private readonly IGenericRepository<Label> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateLabelCommandHandler(IGenericRepository<Label> repository,
                                         IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateLabelCommandResult> HandleAsync(CreateLabelCommand cmd)
        {
            var label = new Label(0, cmd.Title, cmd.ParentId);

            await _repository.Add(label);

            await _unitOfWork.CommitAsync();
      

            return new CreateLabelCommandResult()
            {
                Id = label.Id,
                ParentId = label.ParentId,
                Title = label.Title
            };
        }
    }
}