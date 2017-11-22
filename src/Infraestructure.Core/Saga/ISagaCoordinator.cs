using System;

namespace Infraestructure.Core.Saga
{
    public interface ISagaCoordinator
    {
        DateTime Timeout { get; }
        bool Compleeted { get; }
    }
}