namespace MozaeekCore.ApplicationService.Contract
{

    public class PagingContract
    {
        public PagingContract()
        {
        }

        public PagingContract(int pageSize, int pageNumber, string sort, string order)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            Sort = sort;
            Order = order;
        }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }

    }
}