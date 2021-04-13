using System;

namespace MozaeekCore.Core.Events
{
    public interface IEvent
    {
        public Guid EventId { get; set; }
        public DateTime PublishDateTime { get; set; }
    }
}
