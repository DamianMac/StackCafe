using System;
using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using StackMechanics.MessageContracts.Events;

namespace StackMechanics.Barista.Rules.WhenACustomerPlacesAnOrder
{
    public class MakeThemTheirCoffee : IHandleCompetingEvent<OrderPlacedEvent>
    {
        private readonly IBus _bus;

        public MakeThemTheirCoffee(IBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(OrderPlacedEvent busEvent)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            await _bus.Publish(new OrderIsReadyEvent());
        }
    }
}