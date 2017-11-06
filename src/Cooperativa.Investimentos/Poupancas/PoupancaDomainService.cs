using Cooperativa.Investimentos.Poupancas.Adapters;
using Cooperativa.NucleoCompartilhado.ContextoComunicacao.Contratos;
using Infraestructure.CrossCutting.Contexts;

namespace Cooperativa.Investimentos.Poupancas
{
    public sealed class PoupancaDomainService : IPoupancaDomainService
    {
        private readonly IRequestContext _requestContext;
        private readonly IPoupancaStorer _poupancaStorer;
        private readonly ILancamentoContaCorrenteAdapter _lancamentoContaCorrenteAdapter;

        public PoupancaDomainService(ILancamentoContaCorrenteAdapter lancamentoContaCorrenteAdapter, IRequestContext requestContext, IPoupancaStorer poupancaStorer)
        {
            _lancamentoContaCorrenteAdapter = lancamentoContaCorrenteAdapter;
            _requestContext = requestContext;
            _poupancaStorer = poupancaStorer;
        }

        public void Handle(CriarNovaPoupancaCommand command)
        {
            var dataAniversarioPoupanca = _requestContext.CurrentDate.AddDays(30);
            var poupanca = new Poupanca(command.ContaCorrente, command.Valor, dataAniversarioPoupanca);
            _poupancaStorer.Save(poupanca);

            _lancamentoContaCorrenteAdapter.EfetuarLancamentoContaCorrente(new EfetuarLancamentoContaCorrenteRequisicao(
                command.ContaCorrente.ContaCorrenteId, poupanca.ToString(), command.Valor));
        }
    }
}