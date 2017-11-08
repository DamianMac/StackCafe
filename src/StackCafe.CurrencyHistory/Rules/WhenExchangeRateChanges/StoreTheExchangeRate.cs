using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Events;
using ILogger = Serilog.ILogger;
using StackCafe.CurrencyHistory.Services;

namespace StackCafe.CurrencyHistory.Rules.WhenExchangeRateChanges
{
    public class MakeThemTheirCoffee : IHandleMulticastEvent<CurrencyExchangeRateUpdatedEvent>
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;
        readonly IExchangeRateRepository _exchangeRateRepository;

        public MakeThemTheirCoffee(IBus bus, ILogger logger,IExchangeRateRepository exchangeRateRepository)
        {
            this._exchangeRateRepository = exchangeRateRepository;
            _bus = bus;
            _logger = logger;
        }

        public Task Handle(CurrencyExchangeRateUpdatedEvent busEvent)
        {
            _exchangeRateRepository.Add(busEvent.CurrencyExchangeRate);
            return Task.FromResult(true);
        }
    }
}