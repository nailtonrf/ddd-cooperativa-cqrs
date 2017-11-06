using System;
using Infraestructure.Core.Messaging;

namespace Infraestructure.CrossCutting.Contexts
{
    public interface IRequestContext
    {
        Guid Id { get; }
        DateTime CurrentDateTime { get; }
        DateTime CurrentDate { get; }
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}