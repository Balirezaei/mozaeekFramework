using System;

namespace RssRetriveProcess.Model
{
    public class RssRetriveHistory
    {
        public long Id { get; set; }
        public long RssId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int NewsCount { get; set; }

    }
}