using System.Collections.Generic;

namespace MozaeekCore.Core.ResponseMessages
{
    public class ListResult<T>//: BaseResult
    {
        public List<T> List { get; set; }
    }
}
