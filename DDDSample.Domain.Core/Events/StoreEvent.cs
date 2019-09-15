using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Core.Events
{
    public class StoredEvent :Event
    {
        public StoredEvent(Event theEvent, string date, string user)
        {
            Id = 0;
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = Data;
            User = user;
        }

        protected StoredEvent() { }

        public int Id { get; private set; }

        public string Data { get; private set; }

        public string User { get; private set; }
    }
}
