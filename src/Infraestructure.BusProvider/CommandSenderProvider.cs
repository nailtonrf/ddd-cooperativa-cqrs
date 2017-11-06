using Infraestructure.Core.Injector;
using Infraestructure.Core.Messaging;

namespace Infraestructure.BusProvider
{
    public sealed class CommandSenderProvider : ICommandSender
    {
        private readonly IServiceResolver _resolver;

        public CommandSenderProvider(IServiceResolver resolver)
        {
            _resolver = resolver;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandlerType = typeof(ICommandHandler<TCommand>);
            var commandHandler = _resolver.Resolve(commandHandlerType) as ICommandHandler<TCommand>;
            commandHandler?.Handle(command);
        }
    }
}