using Nimbus;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Commands;
using StackCafe.MessageContracts.Events;
using System.Linq;
using System.Threading.Tasks;
using ILogger = Serilog.ILogger;

namespace StackCafe.Cashier.CommandHandlers
{
    public class PayForOrderCommandHandler : IHandleCommand<PayForOrderCommand>
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;

        public PayForOrderCommandHandler(IBus bus, ILogger logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public async Task Handle(PayForOrderCommand busCommand)
        {
            _logger.Information("{OrderId} has been paid for", busCommand.OrderId);
            await _bus.Publish(new OrderPaidForEvent(busCommand.OrderId));

        }

    }
}