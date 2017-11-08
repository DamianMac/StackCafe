using System.Threading.Tasks;
using Nimbus.Handlers;
using Serilog;
using StackCafe.MakeLineMonitor.Services;
using StackCafe.MessageContracts.Events;

namespace StackCafe.MakeLineMonitor.Rules.WhenItemIsComplete
{
    public class RemoveItFromTheMakeLine : IHandleMulticastEvent<OrderItemCompleteEvent>
    {
        readonly IMakeLineService _makeLine;

        public RemoveItFromTheMakeLine(IMakeLineService makeLine)
        {
            _makeLine = makeLine;
        }

        public Task Handle(OrderItemCompleteEvent busEvent)
        {
            Log.Information("Item {Code} on order {Order} is ready", busEvent.ItemCode, busEvent.OrderId);
            _makeLine.Remove(busEvent.OrderId, busEvent.ItemCode);
            return Task.CompletedTask;
        }
    }
}