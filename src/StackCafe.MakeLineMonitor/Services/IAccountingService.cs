using StackCafe.MessageContracts.Events;
using System;

namespace StackCafe.MakeLineMonitor.Services
{
    public interface IAccountingService
    {
        void Add(Guid orderId, CurrencyAmount amount);
    }

    public class AccountingService : IAccountingService
    {
        public CurrencyAmount Aud { get; set; }
        public CurrencyAmount Btc { get; set; }

        public void Add(Guid orderId, CurrencyAmount amount)
        {
           // switch(amount)
        }
    }
}