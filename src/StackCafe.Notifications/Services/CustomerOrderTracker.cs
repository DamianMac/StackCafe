using System;
using System.Collections.Generic;
using Serilog;
using StackCafe.Notifications.Domain;

namespace StackCafe.Notifications.Services
{
    public class CustomerOrderTracker : ICustomerOrderTracker
    {
        private readonly ILogger _logger;
        private readonly ISmsProvider _smsProvider;

        public CustomerOrderTracker(ILogger logger, ISmsProvider smsProvider)
        {
            _logger = logger;
            _smsProvider = smsProvider;
        }

        private readonly Dictionary<Guid, TrackedOrder> _orders = new Dictionary<Guid, TrackedOrder>();

        public void AddOrder(Guid orderId, string customer, string coffee, string phoneNumber)
        {
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                _logger.Information("{Customer} wants an SMS to {phoneNumber} when the {Coffee} is ready", customer, phoneNumber, coffee);
                _orders.Add(orderId, new TrackedOrder { OrderId = orderId, Coffee = coffee, Customer = customer, PhoneNumber = phoneNumber});

            }

        }

        public void CheckOrder(Guid orderId)
        {

            if (_orders.ContainsKey(orderId))
            {
                var order = _orders[orderId];
                _logger.Information("Time to send {Customer} a message", order.Customer);

                var message = $"Hi {order.Customer} your {order.Coffee} is ready at StackCafe";
                _smsProvider.Send(order.PhoneNumber, message);

                _orders.Remove(orderId);
            }

        }



    }
}