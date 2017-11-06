using System;

namespace Infraestructure.Core.Injector
{
    public interface IServiceResolver
    {
        T Resolve<T>() where T : class;
        object Resolve(Type @type);
    }
}