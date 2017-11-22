using System;

namespace Infraestructure.Core.Messaging
{
    public interface IEvent : IMessage
    {
        Guid EntityId { get; }
    }
}