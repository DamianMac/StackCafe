using System;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Events
{
    public class CurrencyExchangeRateUpdatedEvent : IBusEvent
    {
        public CurrencyExchangeRateUpdatedEvent(CurrencyExchangeRate currencyExchangeRate)
        {
            CurrencyExchangeRate = currencyExchangeRate;
        }

        public CurrencyExchangeRate CurrencyExchangeRate { get; }
    }

    public class CurrencyExchangeRate
    {
        public CurrencyExchangeRate(decimal rate, Currency fromCurrency, Currency toCurrency, DateTimeOffset timeStamp)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            TimeStamp = timeStamp;
            Rate = rate;
        }

        public Currency FromCurrency { get; }
        public Currency ToCurrency { get; }
        public DateTimeOffset TimeStamp { get; }
        public decimal Rate { get; }
    }

    public enum Currency
    {
        AUD,
        USD,
        CAD,
        GBP,        
        BTC
    }
}
