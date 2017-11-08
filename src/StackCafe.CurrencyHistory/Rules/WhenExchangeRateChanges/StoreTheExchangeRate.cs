using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Events;
using ILogger = Serilog.ILogger;

namespace StackCafe.CurrencyHistory.Rules.WhenExchangeRateChanges
{
    public class MakeThemTheirCoffee : IHandleMulticastEvent<CurrencyExchangeRateUpdatedEvent>
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;

        public MakeThemTheirCoffee(IBus bus, ILogger logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public Task Handle(CurrencyExchangeRateUpdatedEvent busEvent)
        {
            return Task.FromResult(true);
        }
    }
}