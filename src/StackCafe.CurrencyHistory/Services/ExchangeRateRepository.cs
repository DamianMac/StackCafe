using StackCafe.MessageContracts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCafe.CurrencyHistory.Services
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        public ExchangeRateRepository()
        {
            _history.Add(new CurrencyExchangeRate(9599.7603m, Currency.BTC, Currency.AUD, new DateTimeOffset(2017, 11, 8, 4, 7, 0, 0, TimeSpan.Zero)));
        }
        private readonly List<CurrencyExchangeRate> _history = new List<CurrencyExchangeRate>();
        public void Add(CurrencyExchangeRate currencyExchangeRate)
        {
            _history.Add(currencyExchangeRate);
        }

        public CurrencyExchangeRate GetLatest(Currency fromCurrency, Currency toCurrency)
        {
            return _history.Where(c => c.FromCurrency == fromCurrency && c.ToCurrency == toCurrency).OrderByDescending(c => c.TimeStamp).FirstOrDefault();
        }
    }
}
