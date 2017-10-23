using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Events
{
    public class CustomerReceivedOrderEvent : IDomainEvent
    {
        public Order Order { get; }

        public CustomerReceivedOrderEvent(Order order)
        {
            Order = order;
        }
    }
}