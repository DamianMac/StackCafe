using System;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Events
{
    public class OrderPaymentRequestedEvent : IBusEvent
    {
        public OrderPaymentRequestedEvent()
        {
        }

        public OrderPaymentRequestedEvent(Guid orderId, decimal price)
        {
            Price = price;
            OrderId = orderId;
        }

        public Guid OrderId { get; set; }
        public decimal Price { get; set; }
    }
}