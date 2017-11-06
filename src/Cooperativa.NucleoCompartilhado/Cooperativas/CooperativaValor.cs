using System;
using Infraestructure.Core;
using Infraestructure.Core.DomainModel;

namespace Cooperativa.NucleoCompartilhado.Cooperativas
{
    public sealed class CooperativaValor : IValueObject
    {
        public Guid Id { get; }
        public string Nome { get; }

        public CooperativaValor(Guid id, string nome)
        {
            Contract.ArgumentNullValidation(id, nameof(id));
            Contract.ArgumentNullValidation(nome, nameof(nome));

            Id = id;
            Nome = nome;
        }
    }
}