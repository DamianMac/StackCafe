using System;
using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Events;
using ILogger = Serilog.ILogger;

namespace StackCafe.Barista.Rules.WhenACustomerPlacesAnOrder
{
    public class MakeThemTheirCoffee : IHandleCompetingEvent<OrderPlacedEvent>
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;
        private static Random random = new Random();

        public MakeThemTheirCoffee(IBus bus, ILogger logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public async Task Handle(OrderPlacedEvent busEvent)
        {
            _logger.Debug("{OrderStatus} {@Items} for {Customer}", "Making", busEvent.Items, busEvent.CustomerName);
            await Task.Delay(TimeSpan.FromSeconds(random.Next(1, 20)));
            _logger.Information("{OrderStatus} {Items} for {Customer}", "Made", busEvent.Items, busEvent.CustomerName);

            await _bus.Publish(new OrderIsReadyEvent(busEvent.OrderId, busEvent.CustomerName, busEvent.Items));
        }
    }
}