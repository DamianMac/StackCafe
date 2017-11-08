using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Commands;
using StackCafe.MessageContracts.Events;
using ILogger = Serilog.ILogger;

namespace StackCafe.Cashier.CommandHandlers
{
    public class PlaceOrderCommandHandler : IHandleCommand<PlaceOrderCommand>
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;

        public PlaceOrderCommandHandler(IBus bus, ILogger logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public async Task Handle(PlaceOrderCommand busCommand)
        {
            _logger.Information("{Customer} would like a {CoffeeType}", busCommand.CustomerName, busCommand.CoffeeType);
            await _bus.Publish(new OrderPlacedEvent(busCommand.OrderId, busCommand.CoffeeType, busCommand.CustomerName));
        }
    }
}