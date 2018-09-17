using System;
using Infraestructure.Core.Injector;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.NativeInjectorProvider
{
    public sealed class InjectorProvider : IInjector
    {
        private readonly IServiceCollection _nativeServices;

        public InjectorProvider(IServiceCollection nativeServices)
        {
            _nativeServices = nativeServices;
            _nativeServices.AddTransient<IServiceResolver>((factory) => new ServiceResolverProvider(_nativeServices.BuildServiceProvider()));
        }

        public void Dispose()
        {
        }

        public IInjector AddTransient<TService, TImplementation>() where TService : class where TImplementation : class, TService
        {
            _nativeServices.AddTransient<TService, TImplementation>();
            return this;
        }

        public IInjector AddTransient(Type service, Type implementation)
        {
            _nativeServices.AddTransient(service, implementation);
            return this;
        }

        public IInjector AddScoped<TService, TImplementation>() where TService : class where TImplementation : class, TService
        {
            _nativeServices.AddScoped<TService, TImplementation>();
            return this;
        }

        public IInjector AddScoped(Type service, Type implementation)
        {
            _nativeServices.AddScoped(service, implementation);
            return this;
        }

        public IInjector AddScopedFactory<TService>(Func<TService> factory) where TService : class
        {
            _nativeServices.AddScoped(s => factory);
            return this;
        }

        public IInjector AddSingleTon<TService, TImplementation>() where TService : class where TImplementation : class, TService
        {
            _nativeServices.AddSingleton<TService, TImplementation>();
            return this;
        }

        public IInjector AddSingleTon(Type service, Type implementation)
        {
            _nativeServices.AddSingleton(service, implementation);
            return this;
        }
    }
}