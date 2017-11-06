using Infraestructure.Core.Injector;

namespace Infraestructure.Core.Bootstrapper
{
    public interface IBootstrapper
    {
        void Load(IInjector injector);
    }
}