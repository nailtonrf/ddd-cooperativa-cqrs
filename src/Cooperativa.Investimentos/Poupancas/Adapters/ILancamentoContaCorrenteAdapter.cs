using Cooperativa.NucleoCompartilhado.ContextoComunicacao.Contratos;

namespace Cooperativa.Investimentos.Poupancas.Adapters
{
    public interface ILancamentoContaCorrenteAdapter
    {
        EfetuarLancamentoContaCorrenteResposta EfetuarLancamentoContaCorrente(
            EfetuarLancamentoContaCorrenteRequisicao requisicao);
    }
}