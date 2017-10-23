using System;

namespace StackMechanics.StackCafe.Domain.Infrastructure
{
    public class Entity : IEntity
    {
        private readonly Entity _parent;

        protected Entity(Guid id, Entity parent)
        {
            _parent = parent;
            Id = id;
        }

        public virtual DomainEventsCollection DomainEvents => _parent.DomainEvents;

        public Guid Id { get; }
    }
}