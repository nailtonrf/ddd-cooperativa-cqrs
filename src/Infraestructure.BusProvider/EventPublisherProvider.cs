using Infraestructure.Core.Injector;
using Infraestructure.Core.Messaging;

namespace Infraestructure.BusProvider
{
    public sealed class EventPublisherProvider : IEventPublisher
    {
        private readonly IServiceResolver _resolver;

        public EventPublisherProvider(IServiceResolver resolver)
        {
            _resolver = resolver;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var eventHandlerType = typeof(IEventHandler<TEvent>);
            var eventHandlers = _resolver.ResolveAll(eventHandlerType);
            foreach (var eventHandler in eventHandlers)
            {
                ((dynamic)eventHandler).Handle(@event);
            }
        }
    }
}