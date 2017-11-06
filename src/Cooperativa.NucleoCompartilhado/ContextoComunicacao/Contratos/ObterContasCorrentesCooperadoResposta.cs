using System;

namespace Cooperativa.NucleoCompartilhado.ContextoComunicacao.Contratos
{
    public sealed class ObterContasCorrentesCooperadoResposta
    {
        public Guid PostoAtendimentoId { get; set; }
        public string PostoAtendimentoNome { get; set; }
        public Guid ContaCorrenteId { get; set; }
        public int ContaCorrenteNumero { get; set; }
        public int ContaCorrenteDigito { get; set; }

        public ObterContasCorrentesCooperadoResposta()
        {
        }

        public ObterContasCorrentesCooperadoResposta(Guid postoAtendimentoId, string postoAtendimentoNome, Guid contaCorrenteId, int contaCorrenteNumero, int contaCorrenteDigito)
        {
            PostoAtendimentoId = postoAtendimentoId;
            PostoAtendimentoNome = postoAtendimentoNome;
            ContaCorrenteId = contaCorrenteId;
            ContaCorrenteNumero = contaCorrenteNumero;
            ContaCorrenteDigito = contaCorrenteDigito;
        }
    }
}