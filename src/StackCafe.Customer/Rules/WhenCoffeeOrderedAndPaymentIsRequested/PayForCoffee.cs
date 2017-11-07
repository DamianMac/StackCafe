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

namespace StackCafe.Customer.Rules.WhenCoffeeOrderedAndPaymentIsRequested
{
    public class PayForCoffee : IHandleMulticastEvent<OrderPaymentRequestedEvent>
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;

        public PayForCoffee(IBus bus, ILogger logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public async Task Handle(OrderPaymentRequestedEvent busEvent)
        {
            _logger.Debug("Paying {Price} for {OrderId}", busEvent.Price, busEvent.OrderId);
            await Task.Delay(TimeSpan.FromSeconds(1));
            _logger.Debug("Paid {Price} for {OrderId}", busEvent.Price, busEvent.OrderId);

            await _bus.Send(new PayForOrderCommand(busEvent.OrderId));
        }
    }
}
