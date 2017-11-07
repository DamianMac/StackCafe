using System.Threading.Tasks;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Events;
using StackCafe.Waiter.Services;

namespace StackCafe.Waiter.Rules.WhenAnOrderIsPaidFor
{
    public class CheckWhetherItHasAlreadyBeenMade : IHandleCompetingEvent<OrderPaidForEvent>
    {
        private readonly IOrderDeliveryService _orderDeliveryService;
        private readonly IOrderLockService orderLockService;

        public CheckWhetherItHasAlreadyBeenMade(IOrderDeliveryService orderDeliveryService, IOrderLockService orderLockService)
        {
            _orderDeliveryService = orderDeliveryService;
            this.orderLockService = orderLockService;
        }

        public async Task Handle(OrderPaidForEvent busEvent)
        {
            await this.orderLockService.Wait();
            _orderDeliveryService.MarkAsPaid(busEvent.OrderId);
            this.orderLockService.Release();
        }
    }
}