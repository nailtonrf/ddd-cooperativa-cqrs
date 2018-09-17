using System;
using System.Linq;
using Cooperativa.Investimentos.Poupancas;
using Infraestructure.Core.Data;

namespace Cooperativa.Investimentos.Storer
{
    public sealed class PoupancaStorer : IPoupancaStorer
    {
        private readonly InvestimentoDbContext _investimentoDbContext;

        public PoupancaStorer(ISessionContext investimentoDbContext)
        {
            _investimentoDbContext = (InvestimentoDbContext)investimentoDbContext;
        }

        public void Dispose()
        {
        }

        public Poupanca GetById(Guid entityId)
        {
            return _investimentoDbContext.Poupancas.First(p => p.Id == entityId);
        }

        public void Update(Poupanca entity)
        {
            _investimentoDbContext.Entry(entity);
            _investimentoDbContext.Commit();
        }

        public void Create(Poupanca entity)
        {
            _investimentoDbContext.Poupancas.Add(entity);
            _investimentoDbContext.Commit();
        }

        public void Delete(Poupanca entity)
        {
            _investimentoDbContext.Poupancas.Remove(entity);
            _investimentoDbContext.Commit();
        }
    }
}