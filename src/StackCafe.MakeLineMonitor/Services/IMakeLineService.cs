using System;
using System.Collections.Generic;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MessageContracts;

namespace StackCafe.MakeLineMonitor.Services
{
    public interface IMakeLineService
    {
        void Add(Guid orderId, List<Item> items);
        void Remove(Guid orderId, string itemCode);
        List<List<MakeLineItem>> Get();
    }
}
