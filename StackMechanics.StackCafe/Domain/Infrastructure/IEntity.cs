using System;

namespace StackMechanics.StackCafe.Domain.Infrastructure
{
    public interface IEntity
    {
        Guid Id { get; }
        DomainEventsCollection DomainEvents { get; }
    }
}