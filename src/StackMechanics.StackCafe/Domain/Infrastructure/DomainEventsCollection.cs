using System.Collections.Generic;

namespace StackMechanics.StackCafe.Domain.Infrastructure
{
    public class DomainEventsCollection
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        public void Raise<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent
        {
            lock (_domainEvents)
            {
                _domainEvents.Add(domainEvent);
            }
        }

        public IDomainEvent[] GetAndClear()
        {
            lock (_domainEvents)
            {
                var domainEvents = _domainEvents.ToArray();
                _domainEvents.Clear();

                return domainEvents;
            }
        }
    }
}