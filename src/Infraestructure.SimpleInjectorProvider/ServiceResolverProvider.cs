using System;
using Infraestructure.Core.Injector;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.NativeInjectorProvider
{
    public sealed class ServiceResolverProvider : IServiceResolver
    {
        private readonly ServiceProvider _nativeServiceProvider;

        public ServiceResolverProvider(ServiceProvider nativeServiceProvider)
        {
            _nativeServiceProvider = nativeServiceProvider;
        }

        public T Resolve<T>() where T : class
        {
            return _nativeServiceProvider.GetService<T>();
        }

        public object Resolve(Type type)
        {
            return _nativeServiceProvider.GetService(type);
        }
    }
}