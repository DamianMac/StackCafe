using Nimbus;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Commands;
using StackCafe.MessageContracts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILogger = Serilog.ILogger;

namespace StackCafe.Customer.CommandHandlers
{
    public class RequestPaymentCommandHandler : IHandleCommand<RequestPaymentCommand>
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;

        public RequestPaymentCommandHandler(IBus bus, ILogger logger)
        {
            _bus = bus;
            _logger = logger;
        }
        
        public async Task Handle(RequestPaymentCommand busCommand)
        {
            _logger.Information("Customer was requested to pay ${Price} for their coffee order {OrderId}", busCommand.Price, busCommand.OrderId);
            await _bus.Publish(new OrderPaymentRequestedEvent(busCommand.OrderId, busCommand.Price));
        }
    }

}
