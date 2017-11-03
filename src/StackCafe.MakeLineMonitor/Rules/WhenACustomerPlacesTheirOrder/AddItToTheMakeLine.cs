using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Events;
using ILogger = Serilog.ILogger;

namespace StackCafe.MakeLineMonitor.Rules.WhenACustomerPlacesTheirOrder
{
    public class AddItToTheMakeLine : IHandleMulticastEvent<OrderPlacedEvent>
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;

        public AddItToTheMakeLine(IBus bus, ILogger logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public Task Handle(OrderPlacedEvent busEvent)
        {
            _logger.Debug("{Coffee} for order {OrderId} is on the make-line", busEvent.CoffeeType, busEvent.OrderId);
            return Task.CompletedTask;
        }
    }
}
