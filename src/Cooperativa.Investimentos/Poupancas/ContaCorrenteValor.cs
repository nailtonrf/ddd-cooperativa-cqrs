using System;
using Infraestructure.Core.DomainModel;

namespace Cooperativa.Investimentos.Poupancas
{
    public sealed class ContaCorrenteValor : IValueObject
    {
        public Guid CooperativaId { get; }
        public Guid PostoAtendimentoId { get; }
        public Guid ContaCorrenteId { get; }
        public int Numero { get; }
        public int Digito { get; }

        public ContaCorrenteValor(Guid cooperativaId, Guid postoAtendimentoId, Guid contaCorrenteId, int numero, int digito)
        {
            CooperativaId = cooperativaId;
            PostoAtendimentoId = postoAtendimentoId;
            ContaCorrenteId = contaCorrenteId;
            Numero = numero;
            Digito = digito;
        }
    }
}