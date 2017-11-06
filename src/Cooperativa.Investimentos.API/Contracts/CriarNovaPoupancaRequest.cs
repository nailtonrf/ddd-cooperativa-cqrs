using System;

namespace Cooperativa.Investimentos.API.Contracts
{
    public sealed class CriarNovaPoupancaRequest
    {
        public Guid CooperativaId { get; set; }
        public Guid PostoAtendimentoId { get; set; }
        public Guid ContaCorrenteId { get; set; }
        public int Numero { get; set; }
        public int Digito { get; set; }
        public decimal Valor { get; set; }
    }
}