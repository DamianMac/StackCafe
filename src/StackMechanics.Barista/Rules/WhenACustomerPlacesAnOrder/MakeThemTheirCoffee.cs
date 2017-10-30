using System;
using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using StackMechanics.MessageContracts.Events;
using ILogger = Serilog.ILogger;

namespace StackMechanics.Barista.Rules.WhenACustomerPlacesAnOrder
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
            _logger.Debug("{OrderStatus} {Coffee} for {Customer}", "Making", busEvent.CoffeeType, busEvent.CustomerName);
            await Task.Delay(TimeSpan.FromSeconds(1));
            _logger.Information("{OrderStatus} {Coffee} for {Customer}", "Made", busEvent.CoffeeType, busEvent.CustomerName);

            await _bus.Publish(new OrderIsReadyEvent());
        }
    }
}