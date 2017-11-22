using Infraestructure.Core.Messaging;

namespace Cooperativa.Investimentos.Poupancas
{
    public sealed class CriarNovaPoupancaCommand : CommandBase
    {
        public ContaCorrente ContaCorrente { get; }
        public decimal Valor { get; }

        public CriarNovaPoupancaCommand(ContaCorrente contaCorrente, decimal valor)
        {
            ContaCorrente = contaCorrente;
            Valor = valor;
        }
    }
}