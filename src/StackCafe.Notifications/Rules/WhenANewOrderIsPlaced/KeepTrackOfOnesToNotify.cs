using System.Threading.Tasks;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Events;
using StackCafe.Notifications.Services;

namespace StackCafe.Notifications.Rules.WhenANewOrderIsPlaced
{
    public class KeepTrackOfOnesToNotify : IHandleMulticastEvent<OrderPlacedEvent>

    {
        private readonly ICustomerOrderTracker _orderTracker;

        public KeepTrackOfOnesToNotify(ICustomerOrderTracker orderTracker)
        {
            _orderTracker = orderTracker;
        }

        public async Task Handle(OrderPlacedEvent busEvent)
        {
            _orderTracker.AddOrder(busEvent.OrderId, busEvent.CustomerName, busEvent.CoffeeType, busEvent.CustomerPhoneNumber);
        }
    }
}