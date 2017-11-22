using System;
using System.Collections.Generic;
using Infraestructure.Core.Messaging;

namespace Infraestructure.Core.Data.Repositories
{
    public interface IEventStorer
    {
        void Store<TEvent>(TEvent @event) where TEvent : IEvent;
        IEnumerable<StoredEvent> All(Guid entityId);
    }
}