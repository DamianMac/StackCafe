using System.Threading.Tasks;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Events;
using StackCafe.Waiter.Services;

namespace StackCafe.Waiter.Rules.WhenAnOrderItemIsReady
{
    public class CheckWhetherOrderIsReady : IHandleMulticastEvent<OrderItemCompleteEvent>
    {
        private readonly IOrderDeliveryService _orderDeliveryService;

        public CheckWhetherOrderIsReady(IOrderDeliveryService orderDeliveryService)
        {
            _orderDeliveryService = orderDeliveryService;
        }

        public Task Handle(OrderItemCompleteEvent busEvent)
        {
            _orderDeliveryService.MarkItemAsMade(busEvent.OrderId, busEvent.ItemCode);
            return Task.CompletedTask;
        }
    }
}