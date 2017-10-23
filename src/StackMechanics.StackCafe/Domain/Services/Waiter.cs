using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate;

namespace StackMechanics.StackCafe.Domain.Services
{
    public class Waiter : IWaiter
    {
        public void DeliverOrderToCustomer(Order order, Customer customer)
        {
            customer.AcceptDeliveryOfOrder(order);
        }
    }
}