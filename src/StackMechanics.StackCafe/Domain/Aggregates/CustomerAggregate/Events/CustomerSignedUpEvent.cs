using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Events
{
    public class CustomerSignedUpEvent: IDomainEvent
    {
        public Customer Customer { get;  }

        public CustomerSignedUpEvent(Customer customer)
        {
            Customer = customer;
        }
    }
}