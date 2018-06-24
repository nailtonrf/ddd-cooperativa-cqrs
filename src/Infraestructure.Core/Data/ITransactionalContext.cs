using System;

namespace Infraestructure.Core.Data
{
    public interface ITransactionalContext : IDisposable
    {
        void Commit();
    }
}