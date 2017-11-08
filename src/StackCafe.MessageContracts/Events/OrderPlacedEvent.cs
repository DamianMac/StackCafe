using System;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Events
{
    public class OrderPlacedEvent : IBusEvent
    {
        public OrderPlacedEvent()
        {
        }

        public OrderPlacedEvent(Guid orderId, string customerName, string[] items)
        {
            OrderId = orderId;
            CustomerName = customerName;
            Items = items;
        }

        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public string[] Items { get; }
    }
}