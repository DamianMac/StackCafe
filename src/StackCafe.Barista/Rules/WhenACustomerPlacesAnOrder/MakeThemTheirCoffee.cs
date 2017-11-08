using System;
using System.Linq;
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

        public MakeThemTheirCoffee(IBus bus, ILogger logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public async Task Handle(OrderPlacedEvent busEvent)
        {
            if (busEvent.Items == null || !busEvent.Items.Any())
            {
                _logger.Error("OrderPlacedEvent {Event} contains no Items", busEvent);
                return;
            }

            //TODO this is so bad
            _logger.Debug("{OrderStatus} {Coffee} for {Customer}", "Making", busEvent.Items[0].ItemName, busEvent.CustomerName);
            _logger.Debug("{OrderStatus} {Food} for {Customer}", "Making", busEvent.Items[1].ItemName, busEvent.CustomerName);

            await Task.Delay(TimeSpan.FromSeconds(1));
            _logger.Information("{OrderStatus} {Coffee} for {Customer}", "Made", busEvent.Items[0].ItemName, busEvent.CustomerName);
            _logger.Information("{OrderStatus} {Coffee} for {Customer}", "Made", busEvent.Items[1].ItemName, busEvent.CustomerName);

            await _bus.Publish(new OrderIsReadyEvent(busEvent.OrderId, busEvent.CustomerName, busEvent.Items));
        }
    }
}
