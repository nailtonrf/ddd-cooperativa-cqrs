using System;

namespace Infraestructure.Core.DomainModel
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}