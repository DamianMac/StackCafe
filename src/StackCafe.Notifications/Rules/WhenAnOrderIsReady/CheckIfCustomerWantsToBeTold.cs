using System.Threading.Tasks;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Events;
using StackCafe.Notifications.Services;

namespace StackCafe.Notifications.Rules.WhenAnOrderIsReady
{
    public class CheckIfCustomerWantsToBeTold : IHandleMulticastEvent<OrderIsReadyEvent>
    {
        private readonly ICustomerOrderTracker _customerOrderTracker;

        public CheckIfCustomerWantsToBeTold(ICustomerOrderTracker customerOrderTracker)
        {
            _customerOrderTracker = customerOrderTracker;
        }

        public async Task Handle(OrderIsReadyEvent busEvent)
        {
            _customerOrderTracker.CheckOrder(busEvent.OrderId);
        }
    }
}