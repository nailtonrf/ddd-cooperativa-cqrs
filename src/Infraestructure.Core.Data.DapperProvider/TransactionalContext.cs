using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Infraestructure.Core.Data.DapperProvider
{
    public class TransactionalContext : ITransactionalContext
    {
        internal readonly IDbConnection Connection;
        private readonly IDbTransaction _transaction;

        public TransactionalContext(IConfiguration configuration)
        {
            Connection = new NpgsqlConnection(configuration.GetConnectionString("DataAccessPostgreSqlProvider"));
            Connection.Open();
            _transaction = Connection.BeginTransaction(IsolationLevel.Snapshot);
        }

        public void Commit()
        {
            _transaction?.Commit();
        }

        public void Dispose()
        {
            _transaction?.Rollback();
            Connection?.Dispose();
        }
    }
}