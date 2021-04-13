using MozaeekCore.Core.Base;

namespace MozaeekCore.ApplicationService.Contract
{
    public class FindByKey : Query
    {
        public FindByKey(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }

    public class FindByKeyEditMode : Query
    {
        public FindByKeyEditMode(long? id)
        {
            Id = id;
        }

        public long? Id { get; set; }
    }

    public class Nothing : Query
    {

    }

    // public class TotalCount
    // {
    //     public long Count { get;private set; }
    //
    //     public TotalCount(long count)
    //     {
    //         Count = count;
    //     }
    // }

}