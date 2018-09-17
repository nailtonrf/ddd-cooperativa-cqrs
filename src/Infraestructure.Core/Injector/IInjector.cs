using System;

namespace Infraestructure.Core.Injector
{
    public interface IInjector : IDisposable
    {
        IInjector AddTransient<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;

        IInjector AddTransient(Type service, Type implementation);

        IInjector AddScoped<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;

        IInjector AddScoped(Type service, Type implementation);

        IInjector AddScopedFactory<TService>(Func<TService> factory)
            where TService : class;

        IInjector AddSingleTon<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;

        IInjector AddSingleTon(Type service, Type implementation);
    }
}