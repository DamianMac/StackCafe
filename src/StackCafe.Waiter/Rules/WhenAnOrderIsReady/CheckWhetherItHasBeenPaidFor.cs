using System.Threading.Tasks;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Events;
using StackCafe.Waiter.Services;

namespace StackCafe.Waiter.Rules.WhenAnOrderIsReady
{
    public class CheckWhetherItHasBeenPaidFor : IHandleCompetingEvent<OrderIsReadyEvent>
    {
        private readonly IOrderDeliveryService _orderDeliveryService;
        private readonly IOrderLockService orderLockService;

        public CheckWhetherItHasBeenPaidFor(IOrderDeliveryService orderDeliveryService, IOrderLockService orderLockService)
        {
            _orderDeliveryService = orderDeliveryService;
            this.orderLockService = orderLockService;
        }

        public async Task Handle(OrderIsReadyEvent busEvent)
        {
            await this.orderLockService.Wait();
            _orderDeliveryService.MarkAsMade(busEvent.OrderId);
            this.orderLockService.Release();
        }
    }
}