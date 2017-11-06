using System;

namespace Infraestructure.Core.DomainModel
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; protected set; }

        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            var compareObj = obj as EntityBase;
            return Equals(compareObj);
        }

        protected bool Equals(EntityBase other)
        {
            return other != null && Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}