namespace Infraestructure.Core.Messaging
{
    public interface ICommandSender
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}