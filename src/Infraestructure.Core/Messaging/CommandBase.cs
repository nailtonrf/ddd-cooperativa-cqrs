using System;

namespace Infraestructure.Core.Messaging
{
    public abstract class CommandBase : ICommand
    {
        public Guid Id { get; }
        public DateTime Created { get; }

        protected CommandBase()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
        }
    }
}