using System;

namespace Infraestructure.Core.Messaging
{
    public class EventBase : IEvent
    {
        public Guid Id { get; }
        public DateTime Created { get; }

        protected EventBase()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
        }
    }
}