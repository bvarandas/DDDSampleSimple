using System;
using DDDSample.Domain.Core.Events;

namespace DDDSample.Domain.Events
{
    public class CustomerRemovedEvent : Event
    {
        public CustomerRemovedEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public int Id { get; set; }
    }
}
