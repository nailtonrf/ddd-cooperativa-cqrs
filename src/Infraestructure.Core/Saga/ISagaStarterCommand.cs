using Infraestructure.Core.Messaging;

namespace Infraestructure.Core.Saga
{
    public interface ISagaStarterCommand<in T> : ICommandHandler<T> where T : ICommand
    {
    }
}