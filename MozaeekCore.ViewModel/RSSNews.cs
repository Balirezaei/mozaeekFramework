using System;

namespace MozaeekCore.ViewModel
{
    public class RSSNews
    {
        public long Id { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string Source { get; set; }
        public long RSSId { get; set; }
    }
}
