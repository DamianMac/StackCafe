using StackCafe.MessageContracts.Events;
using System;
using System.Linq;

namespace StackCafe.CurrencyHistory.Services
{
    public interface IExchangeRateRepository
    {
        void Add(CurrencyExchangeRate currencyExchangeRate);

        CurrencyExchangeRate GetLatest(Currency fromCurrency, Currency toCurrency);
    }
}
