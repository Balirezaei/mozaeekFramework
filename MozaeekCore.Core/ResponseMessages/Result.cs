using System;
using System.Text;

namespace MozaeekCore.Core.ResponseMessages
{
    public class Result<T>: BaseResult
    {
        
        public T Data { get; set; }
    }

    public class Result : BaseResult
    {
        public object Data { get; set; }
    }
}
