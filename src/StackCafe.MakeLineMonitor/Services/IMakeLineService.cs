using System;
using System.Collections.Generic;
using StackCafe.MakeLineMonitor.Models;

namespace StackCafe.MakeLineMonitor.Services
{
    public interface IMakeLineService
    {
        void Add(Guid orderId, string itemName, string itemType);
        void Remove(Guid orderId);
        IEnumerable<MakeLineItem> Get();
    }
}