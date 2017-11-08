using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nimbus.Handlers;
using StackCafe.Cashier.Services;
using StackCafe.MessageContracts.Events;

namespace StackCafe.Cashier.Rules.WhenAnExchangeEventIsReceived
{
    public class UpdateLocalExchangeRate : IHandleCompetingEvent<CurrencyExchangeRateUpdatedEvent>
    {
        private readonly IBtcCurrencyConverterService _btcCurrencyConverterService;

        public UpdateLocalExchangeRate(IBtcCurrencyConverterService btcCurrencyConverterService)
        {
            _btcCurrencyConverterService = btcCurrencyConverterService;
        }

        public Task Handle(CurrencyExchangeRateUpdatedEvent busEvent)
        {
            if (busEvent.CurrencyExchangeRate.FromCurrency == Currency.AUD &&
                busEvent.CurrencyExchangeRate.ToCurrency == Currency.BTC)
            {
                _btcCurrencyConverterService.AUDBTCRate = busEvent.CurrencyExchangeRate.Rate;
                Serilog.Log.Information("Currency Exchange Rate Event Received");
            }

            return Task.CompletedTask;
        }
    }
}
