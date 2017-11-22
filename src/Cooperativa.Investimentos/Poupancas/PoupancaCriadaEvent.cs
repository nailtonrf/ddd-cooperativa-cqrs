using System;
using Infraestructure.Core.Messaging;

namespace Cooperativa.Investimentos.Poupancas
{
    public sealed class PoupancaCriadaEvent : EventBase
    {
        public PoupancaCriadaEvent(Guid cooperativaId, Guid postoAtendimentoId, Guid contaCorrenteId, 
            decimal valor, DateTime aniversario)
        {
            CooperativaId = cooperativaId;
            PostoAtendimentoId = postoAtendimentoId;
            ContaCorrenteId = contaCorrenteId;
            Valor = valor;
            Aniversario = aniversario;
        }

        public Guid CooperativaId { get; }
        public Guid PostoAtendimentoId { get; }
        public Guid ContaCorrenteId { get; }
        public decimal Valor { get; }
        public DateTime Aniversario { get; }
    }
}