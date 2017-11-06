using System;
using Cooperativa.Investimentos.Poupancas.Adapters;
using Cooperativa.NucleoCompartilhado.ContextoComunicacao.Contratos;

namespace Cooperativa.Investimentos.Infrastructure
{
    public sealed class LancamentoContaCorrenteAdapter : ILancamentoContaCorrenteAdapter
    {
        public EfetuarLancamentoContaCorrenteResposta EfetuarLancamentoContaCorrente(
            EfetuarLancamentoContaCorrenteRequisicao requisicao)
        {
            return new EfetuarLancamentoContaCorrenteResposta
            {
                LancamentoData = DateTime.Now,
                LancamentoNumero = "123456",
                LancamentoId = Guid.NewGuid(),
                LancamentoValor = 100
            };
        }
    }
}