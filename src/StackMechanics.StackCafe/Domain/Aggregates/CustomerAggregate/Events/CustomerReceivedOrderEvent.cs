using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Events
{
    public class CustomerReceivedOrderEvent : IDomainEvent
    {
        public CustomerReceivedOrderEvent(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}