using System;

namespace Infraestructure.Core.Injector
{
    public interface IInjector : IServiceResolver, IDisposable
    {
        IInjector Register<TService, TImplementation>(Lifestyle lifestyle = Lifestyle.Trasient)
            where TService : class
            where TImplementation : class, TService;

        IInjector Register(Type service, Type implementation, Lifestyle lifestyle = Lifestyle.Trasient);

        IInjector GetChildContainer();
    }
}