using System;

namespace Infraestructure.Core.Messaging
{
    public sealed class StoredEvent
    {
        public Guid Id { get; }
        public string EventContent { get; }
        public string EventType { get; }
        public bool Published { get; private set; }

        public StoredEvent(string eventContent, string eventType, bool published = false)
        {
            Id = Guid.NewGuid();
            EventContent = eventContent;
            EventType = eventType;
            Published = published;
        }

        public void EventPublished()
        {
            Published = true;
        }
    }
}