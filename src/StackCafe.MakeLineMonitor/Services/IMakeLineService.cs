using StackCafe.MessageContracts.Events;
using System;
using System.Collections.Generic;

namespace StackCafe.MakeLineMonitor.Services
{
    public interface IMakeLineService
    {
        void Add(Guid orderId, string coffeeType);
        void Remove(Guid orderId);
        IEnumerable<string> GetItems();
    }
}