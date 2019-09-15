using System;
using DDDSample.Domain.Core.Events;

namespace DDDSample.Domain.Events
{
    public class AdvRemovedEvent : Event
    {
        public AdvRemovedEvent(int id)
        {
            ID = id;
            AggregateId = id;
        }

        public int ID { get; set; }
    }
}
