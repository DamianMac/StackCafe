using System;
using StackCafe.Waiter.Models;

namespace StackCafe.Waiter.Services
{
    public interface IOrderDeliveryService
    {
        void MarkAsPaid(Guid orderId);

        void MarkAsMade(Guid orderId);

        Order GetOrderFromId(Guid orderId);
    }
}