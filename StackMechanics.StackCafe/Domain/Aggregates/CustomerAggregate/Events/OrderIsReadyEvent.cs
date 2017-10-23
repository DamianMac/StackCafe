using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Events
{
    public class OrderIsReadyEvent : IDomainEvent
    {
        public OrderIsReadyEvent(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}