using System;

namespace Cooperativa.NucleoCompartilhado.ContextoComunicacao.Contratos
{
    public sealed class ObterTodasPoupancasResposta
    {
        public int ContaCorrenteNumero { get; }
        public int ContaCorrenteDigito { get; }
        public decimal Valor { get; }
        public DateTime Aniversario { get; }
        public bool Resgatada { get; }

        public ObterTodasPoupancasResposta()
        {
        }

        public ObterTodasPoupancasResposta(int contaCorrenteNumero, int contaCorrenteDigito, decimal valor, DateTime aniversario, bool resgatada)
        {
            ContaCorrenteNumero = contaCorrenteNumero;
            ContaCorrenteDigito = contaCorrenteDigito;
            Valor = valor;
            Aniversario = aniversario;
            Resgatada = resgatada;
        }
    }
}