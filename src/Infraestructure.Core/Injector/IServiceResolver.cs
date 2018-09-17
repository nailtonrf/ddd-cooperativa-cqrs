using System;
using System.Collections.Generic;

namespace Infraestructure.Core.Injector
{
    public interface IServiceResolver
    {
        T Resolve<T>() where T : class;
        IEnumerable<T> ResolveAll<T>() where T : class;
        object Resolve(Type @type);
        IEnumerable<object> ResolveAll(Type @type);
    }
}