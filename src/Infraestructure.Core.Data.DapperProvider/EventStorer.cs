using System;
using System.Collections.Generic;
using Dapper;
using Infraestructure.Core.Data;
using Infraestructure.Core.Messaging;
using Infraestructure.Core.Serializer;

namespace Infraestructure.Core.Data.DapperProvider
{
    public sealed class EventStorer : IEventStorer
    {
        private readonly ISerializer _serializer;
        private readonly TransactionalContext _transactionalContext;

        public EventStorer(ISerializer serializer, ITransactionalContext transactionalContext)
        {
            _serializer = serializer;
            _transactionalContext = (TransactionalContext)transactionalContext;
        }

        public void Store<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var eventToStore = new StoredEvent(
                _serializer.Serialize(@event),
                @event.GetType().AssemblyQualifiedName);

            _transactionalContext.Connection.Execute(
                "INSERT INTO eventstore (id, eventContent, eventType, published) VALUES (Id, EventContent, EventType, Published)",
                eventToStore);
        }

        public IEnumerable<StoredEvent> All(Guid entityId)
        {
            return _transactionalContext.Connection.Query<StoredEvent>("SELECT * FROM eventstore");
        }
    }
}