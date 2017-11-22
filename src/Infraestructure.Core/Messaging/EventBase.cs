using System;

namespace Infraestructure.Core.Messaging
{
    public abstract class EventBase : IEvent
    {
        public Guid Id { get; }
        public DateTime Created { get; }
        public Guid EntityId { get; }

        protected EventBase()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
        }

        protected EventBase(Guid entityId) : this()
        {
            EntityId = entityId;
        }
    }
}