namespace MozaeekCore.ApplicationService.Contract
{
    public class LabelDto
    {
        public string Title { get; set; }
        public long Id { get; set; }
        public long? ParentId { get; set; }
    }
}