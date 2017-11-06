using System;

namespace Cooperativa.NucleoCompartilhado.ContextoComunicacao.Contratos
{
    public sealed class EfetuarLancamentoContaCorrenteResposta
    {
        public Guid LancamentoId { get; set; }
        public string LancamentoNumero { get; set; }
        public DateTime LancamentoData { get; set; }
        public decimal LancamentoValor { get; set; }
    }
}