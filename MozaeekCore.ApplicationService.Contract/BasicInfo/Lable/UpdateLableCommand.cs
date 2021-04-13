using MozaeekCore.Core.Base;

namespace MozaeekCore.ApplicationService.Contract
{
    public class UpdateLabelCommand : Command
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long? ParentId { get; set; }
    }
}