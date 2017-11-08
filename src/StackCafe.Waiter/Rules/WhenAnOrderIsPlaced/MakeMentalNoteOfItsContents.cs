using System.Linq;
using System.Threading.Tasks;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Events;
using StackCafe.Waiter.Services;

namespace StackCafe.Waiter.Rules.WhenAnOrderIsPlaced
{
    public class CheckWhetherItHasBeenPaidFor : IHandleCompetingEvent<OrderPlacedEvent>
    {
        private readonly IOrderDeliveryService _orderDeliveryService;

        public CheckWhetherItHasBeenPaidFor(IOrderDeliveryService orderDeliveryService)
        {
            _orderDeliveryService = orderDeliveryService;
        }

        public Task Handle(OrderPlacedEvent busEvent)
        {
            _orderDeliveryService.AddUnmadeOrder(busEvent.OrderId, busEvent.Items.Select(i => i.ItemCode).ToList());
            return Task.CompletedTask;
        }
    }
}