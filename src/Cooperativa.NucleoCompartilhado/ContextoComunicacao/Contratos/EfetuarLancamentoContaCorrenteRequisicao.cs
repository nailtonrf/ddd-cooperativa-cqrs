using System;

namespace Cooperativa.NucleoCompartilhado.ContextoComunicacao.Contratos
{
    public sealed class EfetuarLancamentoContaCorrenteRequisicao
    {
        public Guid ContaCorrenteId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public EfetuarLancamentoContaCorrenteRequisicao()
        {
        }

        public EfetuarLancamentoContaCorrenteRequisicao(Guid contaCorrenteId, string descricao, decimal valor) : this()
        {
            ContaCorrenteId = contaCorrenteId;
            Descricao = descricao;
            Valor = valor;
        }
    }
}