using Infraestructure.Core.Injector;
using Infraestructure.Core.Messaging;

namespace Infraestructure.BusProvider
{
    public static class BusProviderBootstrapperExtensions
    {
        public static void UseInMemoryBusProvider(this IInjector injector)
        {
            injector.AddTransient<ICommandSender, CommandSenderProvider>();
            injector.AddTransient<IEventPublisher, EventPublisherProvider>();
        }
    }
}