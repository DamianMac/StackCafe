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
