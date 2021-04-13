using MozaeekCore.Core.Base;

namespace MozaeekCore.ApplicationService.Contract
{
    public class DeleteLabelCommand : Command
    {
        public DeleteLabelCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}