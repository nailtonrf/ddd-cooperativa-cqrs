using System;
using System.Linq;
using Dapper;
using Infraestructure.Core.DomainModel;

namespace Infraestructure.Core.Data.DapperProvider
{
    public abstract class Storer<T> : IStorer<T> where T : class, IEntity
    {
        private readonly TransactionalContext _transactionalContext;

        protected Storer(ITransactionalContext transactionalContext)
        {
            _transactionalContext = (TransactionalContext)transactionalContext;
        }

        public virtual T GetById(Guid entityId)
        {
            const string tableName = nameof(T);
            return _transactionalContext.Connection.Query<T>($"SELECT * FROM {tableName} WHERE id = @id", new { id = entityId }).First();
        }

        public abstract void Create(T entity);

        public abstract void Update(T entity);

        public virtual void Delete(T entity)
        {
            const string tableName = nameof(T);
            _transactionalContext.Connection.Execute($"DELETE FROM {tableName} WHERE id = @id", new { id = entity.Id });
        }

        public void Dispose()
        {
        }
    }
}