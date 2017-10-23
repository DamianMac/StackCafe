using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Events
{
    public class OrderPaidForEvent : IDomainEvent
    {
        public OrderPaidForEvent(Customer customer, Order order)
        {
            Customer = customer;
            Order = order;
        }

        public Customer Customer { get; }
        public Order Order { get; }
    }
}