using System;
using System.Collections.Generic;
using StackCafe.MakeLineMonitor.Models;

namespace StackCafe.MakeLineMonitor.Services
{
    public interface IMakeLineService
    {
        void Add(Guid orderId, string coffeeType);
        void Remove(Guid orderId);
        MakeLineItem[] GetOrders();
    }
}