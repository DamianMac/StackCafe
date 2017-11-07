using System;
using StackCafe.MakeLineMonitor.Models;

namespace StackCafe.MakeLineMonitor.Services
{
    public interface IMakeLineService
    {
        void Add(Guid orderId, string coffeeType);

        void SetPaid(Guid orderId);

        void Remove(Guid orderId);

        Order[] CurrentOrders { get; }
    }
}