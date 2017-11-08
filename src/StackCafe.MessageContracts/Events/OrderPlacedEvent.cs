using System;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Events
{
    public class OrderPlacedEvent : IBusEvent
    {
        public OrderPlacedEvent()
        {
        }

        public OrderPlacedEvent(Guid orderId, string itemName, string itemType, string customerName)
        {
            OrderId = orderId;
            ItemName = itemName;
            ItemType = itemType;
            CustomerName = customerName;
        }

        public Guid OrderId { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string CustomerName { get; set; }
    }
}