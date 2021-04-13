using System.Collections.Generic;

namespace MozaeekCore.Core.ResponseMessages
{
    public class ResponseFactory
    {
        public static Result<T> Create<T>(T data)
        {
            return new Result<T>()
            {
                Data=data               
            };
        }
        public static ListResult<T> Create<T>(List<T> data)
        {
            return new ListResult<T>()
            {
                List = data
            };
        }
        public static PagedListResult<T> Create<T>(List<T> data,int pageNo,int pageSize,int totalCount)
        {
            return new PagedListResult<T>()
            {
                List = data,
                PageNumber=pageNo,
                PageSize=pageSize,
                TotalCount=totalCount
            };
        }
        
    }
}
