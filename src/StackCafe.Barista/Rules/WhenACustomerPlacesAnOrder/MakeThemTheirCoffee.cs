using System;
using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Commands;
using StackCafe.MessageContracts.Events;
using ILogger = Serilog.ILogger;

namespace StackCafe.Barista.Rules.WhenACustomerPlacesAnOrder
{
    public class MakeThemTheirCoffee : IHandleCompetingEvent<OrderPlacedEvent>
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;

        public MakeThemTheirCoffee(IBus bus, ILogger logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public async Task Handle(OrderPlacedEvent busEvent)
        {
            await _bus.Send(new MakeCoffeeCommand(busEvent.OrderId, busEvent.CustomerName, busEvent.CoffeeType));
        }
    }
}