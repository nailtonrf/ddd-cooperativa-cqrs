using Infraestructure.CrossCutting.Contexts;

namespace Cooperativa.Investimentos.Poupancas
{
    public sealed class PoupancaDomainService : IPoupancaDomainService
    {
        private readonly IRequestContext _requestContext;
        private readonly IPoupancaStorer _poupancaStorer;

        public PoupancaDomainService(IRequestContext requestContext, IPoupancaStorer poupancaStorer)
        {
            _requestContext = requestContext;
            _poupancaStorer = poupancaStorer;
        }

        public void Handle(CriarNovaPoupancaCommand command)
        {
            var dataAniversarioPoupanca = _requestContext.CurrentDate.AddDays(30);
            var poupanca = new Poupanca(command.ContaCorrente, command.Valor, dataAniversarioPoupanca);
            _poupancaStorer.Create(poupanca);

            PublicarEventoPoupancaCriada(poupanca);
        }

        private void PublicarEventoPoupancaCriada(Poupanca poupanca)
        {
            var poupancaCriacaEvent = new PoupancaCriadaEvent(poupanca.ContaCorrente.CooperativaId,
                poupanca.ContaCorrente.PostoAtendimentoId,
                poupanca.ContaCorrente.ContaCorrenteId, poupanca.Valor, poupanca.Aniversario);

            _requestContext.PublishEvent(poupancaCriacaEvent);
        }
    }
}