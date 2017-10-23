using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Events;
using StackMechanics.StackCafe.Domain.Services;
using StackMechanics.StackCafe.Infrastructure;

namespace StackMechanics.StackCafe.Domain.Rules.WhenAnOrderIsReady
{
    public class GiveItToTheCustomer : IHandleEvent<OrderIsReadyEvent>
    {
        private readonly IWaiter _waiter;

        public GiveItToTheCustomer(IWaiter waiter)
        {
            _waiter = waiter;
        }

        public void Handle(OrderIsReadyEvent e)
        {
            _waiter.DeliverOrderToCustomer(e.Order, e.Order.Customer);
        }
    }
}