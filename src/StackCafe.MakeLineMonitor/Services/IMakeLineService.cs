using StackCafe.MakeLineMonitor.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace StackCafe.MakeLineMonitor.Services
{
    public interface IMakeLineService
    {
        void Add(Guid orderId, string coffeeType);
        void Remove(Guid orderId);

        IEnumerable<OrderItem> GetMakeline();
    }
}