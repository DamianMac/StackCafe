using System.Threading.Tasks;
using Nimbus.Handlers;
using Serilog;
using StackMechanics.MessageContracts.Events;

namespace StackMechanics.Waiter.Rules.WhenAnOrderIsReady
{
    public class GiveItToTheCustomer : IHandleCompetingEvent<OrderIsReadyEvent>
    {
        private readonly ILogger _logger;

        public GiveItToTheCustomer(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Handle(OrderIsReadyEvent busEvent)
        {
            _logger.Information("Delivered {CoffeeOrder} to {Customer}", busEvent.CoffeeType, busEvent.CustomerName);
        }
    }
}