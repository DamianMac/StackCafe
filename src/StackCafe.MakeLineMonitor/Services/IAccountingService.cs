using StackCafe.MessageContracts.Events;
using System;

namespace StackCafe.MakeLineMonitor.Services
{
    public interface IAccountingService
    {
        void Add(Guid orderId, CurrencyAmount amount);

        CurrencyAmount Aud { get; } 
        CurrencyAmount Btc { get; }
    }
}