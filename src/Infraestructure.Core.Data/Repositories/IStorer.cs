using Infraestructure.Core.DomainModel;
using System;

namespace Infraestructure.Core.Data.Repositories
{
    public interface IStorer<T> : IDisposable where T : class, IEntity
    {
        T GetById(Guid entityId);
        void Save(T entity);
        void Delete(T entity);
    }
}