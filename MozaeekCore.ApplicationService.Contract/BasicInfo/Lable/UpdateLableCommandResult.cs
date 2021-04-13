namespace MozaeekCore.ApplicationService.Contract
{
    public class UpdateLabelCommandResult
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long? ParentId { get; set; }
    }
}