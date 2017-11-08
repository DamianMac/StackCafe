using System;
using System.Collections.Generic;

namespace StackCafe.Waiter.Services
{
    public interface IOrderDeliveryService
    {
        void AddUnmadeOrder(Guid orderId, List<string> items);
        void MarkItemAsMade(Guid orderId, string itemCode);
        void MarkAsPaid(Guid orderId);
        void MarkAsMade(Guid orderId);
        bool HasBeenMade(Guid orderId);
        bool HasBeenPaid(Guid orderId);
    }
}