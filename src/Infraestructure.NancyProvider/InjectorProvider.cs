using System;
using Infraestructure.Core.Injector;
using Nancy.TinyIoc;

namespace Infraestructure.NancyProvider
{
    public sealed class InjectorProvider : IInjector
    {
        private readonly TinyIoCContainer _tinyIoCContainer;

        public InjectorProvider(TinyIoCContainer tinyIoCContainer)
        {
            _tinyIoCContainer = tinyIoCContainer;
        }

        public IInjector Register<TService, TImplementation>(Lifestyle lifestyle = Lifestyle.Trasient) where TService : class where TImplementation : class, TService
        {
            if (lifestyle == Lifestyle.Trasient)
            {
                _tinyIoCContainer.Register<TService, TImplementation>().AsMultiInstance();
            }
            else
            {
                _tinyIoCContainer.Register<TService, TImplementation>().AsSingleton();
            }
            return this;
        }

        public IInjector Register(Type service, Type implementation, Lifestyle lifestyle = Lifestyle.Trasient)
        {
            if (lifestyle == Lifestyle.Trasient)
            {
                _tinyIoCContainer.Register(service, implementation).AsMultiInstance();
            }
            else
            {
                _tinyIoCContainer.Register(service, implementation).AsSingleton();
            }
            return this;
        }

        public IInjector GetChildContainer()
        {
            return new InjectorProvider(_tinyIoCContainer.GetChildContainer());
        }

        public void Dispose()
        {
            _tinyIoCContainer?.Dispose();
        }

        public T Resolve<T>() where T : class
        {
            return _tinyIoCContainer.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _tinyIoCContainer.Resolve(@type);
        }
    }
}