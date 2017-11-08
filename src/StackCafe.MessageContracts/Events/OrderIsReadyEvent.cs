using System;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Events
{
    public class OrderIsReadyEvent : IBusEvent
    {
        public OrderIsReadyEvent()
        {
        }

        public OrderIsReadyEvent(Guid orderId,  string customerName, OrderItemDto[] items)
        {
            OrderId = orderId;
            CustomerName = customerName;
            Items = items;
        }

        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public OrderItemDto[] Items { get; }
    }
}