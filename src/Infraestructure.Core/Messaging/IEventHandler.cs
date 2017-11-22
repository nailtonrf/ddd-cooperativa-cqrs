namespace Infraestructure.Core.Messaging
{
    public interface IEventHandler<in T> where T : IEvent
    {
        void Handle(T @event);
    }
}