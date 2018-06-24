using System;
using Infraestructure.Core.Messaging;

namespace Infraestructure.Core.Contexts
{
    public interface IRequestContext
    {
        Guid Id { get; }
        DateTime CurrentDateTime { get; }
        DateTime CurrentDate { get; }
        void SendCommand<TCommand>(TCommand command) where TCommand : ICommand;
        void PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}