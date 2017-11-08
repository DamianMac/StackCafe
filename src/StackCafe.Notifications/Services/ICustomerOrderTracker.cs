using System;

namespace StackCafe.Notifications.Services
{
    public interface ICustomerOrderTracker
    {
        void AddOrder(Guid orderId, string customer, string coffee, string phoneNumber);
        void CheckOrder(Guid orderId);
    }
}