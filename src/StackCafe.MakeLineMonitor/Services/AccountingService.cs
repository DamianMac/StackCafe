using StackCafe.MessageContracts.Events;
using System;

namespace StackCafe.MakeLineMonitor.Services
{
    public class AccountingService : IAccountingService
    {
        public CurrencyAmount Aud { get; set; } = new CurrencyAmount(Currency.AUD, 0);
        public CurrencyAmount Btc { get; set; } = new CurrencyAmount(Currency.BTC, 0);

        public void Add(Guid orderId, CurrencyAmount amount)
        {
            switch (amount.Currency)
            {
                case Currency.BTC:
                    Btc.Amount += amount.Amount;
                    break;
                case Currency.AUD:
                    Aud.Amount += amount.Amount;
                    break;
                default:
                    break;
            }
        }
    }
}