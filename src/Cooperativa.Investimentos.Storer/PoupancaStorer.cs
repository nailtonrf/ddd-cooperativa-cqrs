using System;
using System.Collections.Generic;
using System.Linq;
using Cooperativa.Investimentos.Poupancas;

namespace Cooperativa.Investimentos.Storer
{
    public sealed class PoupancaStorer : IPoupancaStorer
    {
        private readonly List<Poupanca> _poupancas;

        public PoupancaStorer()
        {
            _poupancas = new List<Poupanca>
            {
                new Poupanca(new ContaCorrenteValor(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 1, 9),
                    100, DateTime.Now)
            };
        }

        public void Save(Poupanca entity)
        {
            _poupancas.Add(entity);
        }

        public void Delete(Poupanca entity)
        {
            _poupancas.Remove(entity);
        }

        public Poupanca GetById(Guid id)
        {
            return _poupancas.First(p => p.Id == id);
        }

        public void Dispose()
        {
        }
    }
}