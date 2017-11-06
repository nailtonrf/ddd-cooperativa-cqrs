using Infraestructure.Core.Bootstrapper;
using Infraestructure.Core.Injector;
using Infraestructure.Core.Messaging;

namespace Infraestructure.BusProvider
{
    public sealed class InMemoryBusProviderBootstrapper : IBootstrapper
    {
        public void Load(IInjector injector)
        {
            injector.Register<ICommandSender, CommandSenderProvider>();
        }
    }
}