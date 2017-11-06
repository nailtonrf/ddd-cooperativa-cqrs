using System;
using Infraestructure.Core;
using Infraestructure.Core.DomainModel;

namespace Cooperativa.NucleoCompartilhado.Cooperativas
{
    public sealed class PostoAtendimentoValor : IValueObject
    {
        public Guid Id { get; }
        public string Nome { get; }
        public CooperativaValor Cooperativa { get; }

        public PostoAtendimentoValor(Guid id, string nome, CooperativaValor cooperativa)
        {
            Contract.ArgumentNullValidation(id, nameof(id));
            Contract.ArgumentNullValidation(nome, nameof(nome));
            Contract.ArgumentNullValidation(cooperativa, nameof(cooperativa));

            Id = id;
            Nome = nome;
            Cooperativa = cooperativa;
        }
    }
}
