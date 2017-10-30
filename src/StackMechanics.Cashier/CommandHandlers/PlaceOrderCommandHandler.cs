using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using StackMechanics.MessageContracts.Commands;
using StackMechanics.MessageContracts.Events;
using ILogger = Serilog.ILogger;

namespace StackMechanics.Cashier.CommandHandlers
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
            await _bus.Publish(new OrderPlacedEvent(busCommand.CoffeeType, busCommand.CustomerName));
        }
    }
}