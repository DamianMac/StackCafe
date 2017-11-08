using System;
using System.Collections.Generic;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Events
{
    public class OrderPlacedEvent : IBusEvent
    {
        public OrderPlacedEvent()
        {
        }

        public OrderPlacedEvent(Guid orderId, string customerName, List<Item> items)
        {
            OrderId = orderId;
            CustomerName = customerName;
            Items = items;

        }

        public Guid OrderId { get; set; }

        public string CustomerName { get; set; }

        public List<Item> Items = new List<Item>();
    }

    public class Item
    {
        public string ItemName { get; set; }

        public int ItemPrepTime { get; set; }

        public string ItemType { get; set; }
    }
}
