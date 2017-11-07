using System.Threading.Tasks;
using Nimbus.Handlers;
using StackCafe.MakeLineMonitor.Services;
using StackCafe.MessageContracts.Events;

namespace StackCafe.MakeLineMonitor.Rules.WhenACustomerPaysTheirOrder
{
    public class UpdateItToTheMakeLine : IHandleMulticastEvent<OrderPaidForEvent>
    {
        private readonly IMakeLineService _makeLine;

        public UpdateItToTheMakeLine(IMakeLineService makeLine)
        {
            _makeLine = makeLine;
        }

        public Task Handle(OrderPaidForEvent busEvent)
        {
            _makeLine.SetPaid(busEvent.OrderId);
            return Task.CompletedTask;
        }
    }
}