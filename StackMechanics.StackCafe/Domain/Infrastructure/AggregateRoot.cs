using System;

namespace StackMechanics.StackCafe.Domain.Infrastructure
{
    public class AggregateRoot : Entity, IAggregateRoot
    {
        public AggregateRoot(Guid id) : base(id, null)
        {
            DomainEvents = new DomainEventsCollection();
        }

        public override DomainEventsCollection DomainEvents { get; }
    }
}