using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Core.Events
{
    public class StoredEvent :Event
    {
        public StoredEvent(Event theEvent, string date, string user)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = Data;
            User = user;
        }

        protected StoredEvent() { }

        public Guid Id { get; private set; }

        public string Data { get; private set; }

        public string User { get; private set; }
    }
}
