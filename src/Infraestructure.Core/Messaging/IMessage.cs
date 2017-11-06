using System;

namespace Infraestructure.Core.Messaging
{
    public interface IMessage
    {
        Guid Id { get; }
        DateTime Created { get; }
    }
}