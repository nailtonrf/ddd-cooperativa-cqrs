using Infraestructure.Core.Data;
using System;
using System.Collections.Generic;
using Infraestructure.Core.Messaging;

namespace Cooperativa.Investimentos.Storer
{
    public sealed class EventStorer : IEventStorer
    {
        public void Store<TEvent>(TEvent @event) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StoredEvent> All(Guid entityId)
        {
            throw new NotImplementedException();
        }
    }
}