using System;

namespace StackMechanics.Waiter.Services
{
    public interface IOrderDeliveryService
    {
        void MarkAsPaid(Guid orderId);
        void MarkAsMade(Guid orderId);
    }
}