using System;
using Infraestructure.Core;
using Infraestructure.Core.DomainModel;

namespace Cooperativa.Investimentos.Poupancas
{
    public class Poupanca : EntityBase
    {
        public ContaCorrente ContaCorrente { get; }
        public decimal Valor { get; private set; }
        public DateTime Aniversario { get; private set; }
        public bool Resgatada { get; private set; }

        private Poupanca()
        {
            Resgatada = false;
        }

        public Poupanca(ContaCorrente contaCorrente, decimal valor, DateTime aniversario) : this()
        {
            Contract.ArgumentNullValidation(contaCorrente, nameof(contaCorrente));
            Contract.Requires<ArgumentOutOfRangeException>(valor > 0, nameof(valor));

            ContaCorrente = contaCorrente;
            Valor = valor;
            Aniversario = aniversario;
        }

        public void IncorporarRendimentoAniversario(decimal taxaRendimento)
        {
            Contract.Requires<ArgumentOutOfRangeException>(taxaRendimento > 0, nameof(taxaRendimento));

            Valor = Math.Round(Valor + ((Valor * taxaRendimento) / 100), 4);
            Aniversario = Aniversario.AddDays(30);
        }

        public void ResgatarValor(decimal valor)
        {
            Contract.Requires<ArgumentOutOfRangeException>(valor > 0, nameof(valor));
            Contract.Requires<ArgumentOutOfRangeException>(valor <= Valor, $"Resgate excedeu o valor do saldo - {Valor}");

            Valor -= valor;
            if (Valor == 0)
            {
                Resgatada = true;
            }
        }
    }
}