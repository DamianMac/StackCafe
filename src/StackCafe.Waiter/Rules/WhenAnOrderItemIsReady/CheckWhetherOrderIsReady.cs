using System.Threading.Tasks;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Events;
using StackCafe.Waiter.Services;

namespace StackCafe.Waiter.Rules.WhenAnOrderItemIsReady
{
    public class CheckWhetherOrderIsReady : IHandleCompetingEvent<OrderItemCompleteEvent>
    {
        private readonly IOrderDeliveryService _orderDeliveryService;

        public CheckWhetherOrderIsReady(IOrderDeliveryService orderDeliveryService)
        {
            _orderDeliveryService = orderDeliveryService;
        }

        public Task Handle(OrderItemCompleteEvent busEvent)
        {
            _orderDeliveryService.MarkItemAsMade(busEvent.OrderId, busEvent.ItemCode);
            if (_orderDeliveryService.HasBeenMade(busEvent.OrderId))
            {
                _orderDeliveryService.MarkAsMade(busEvent.OrderId);
            }
            return Task.CompletedTask;
        }
    }
}