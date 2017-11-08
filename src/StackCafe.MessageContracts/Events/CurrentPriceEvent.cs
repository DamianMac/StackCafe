using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Events
{
    public class CurrentPriceEvent : IBusEvent
    {
        public CurrentPriceEvent(CurrencyAmount currencyAmount)
        {
            CurrencyAmount = currencyAmount;
        }

        public CurrencyAmount CurrencyAmount { get; }
    }

    public class CurrencyAmount
    {
        public CurrencyAmount(decimal amount, Currency currency)
        {
            Currency = currency;
            Amount = amount;
        }

        public Currency Currency { get; }
        public decimal Amount { get; }
    }

    public enum Currency
    {
        AUD,
        BTC
    }
}
