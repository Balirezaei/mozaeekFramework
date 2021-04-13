using MozaeekCore.Core.Base;

namespace MozaeekCore.ApplicationService.Contract
{
    public class CreateLabelCommand : Command
    {
        public string Title { get; set; }
        public long? ParentId { get; set; }
    }

    public class LabelFilterContract : PagingContract
    {

    }
}