namespace MozaeekCore.ApplicationService.Contract
{
    public class LabelTotalCount
    {
        public long Count { get; private set; }

        public LabelTotalCount(long count)
        {
            Count = count;
        }
    }
}