using Infraestructure.Core.Messaging;

namespace Cooperativa.Investimentos.Poupancas
{
    public sealed class CriarNovaPoupancaCommand : CommandBase
    {
        public ContaCorrenteValor ContaCorrente { get; }
        public decimal Valor { get; }

        public CriarNovaPoupancaCommand(ContaCorrenteValor contaCorrente, decimal valor)
        {
            ContaCorrente = contaCorrente;
            Valor = valor;
        }
    }
}