using System;
using System.Collections.Generic;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Events
{
    public class OrderIsReadyEvent : IBusEvent
    {
        public OrderIsReadyEvent()
        {
        }

        public OrderIsReadyEvent(Guid orderId, string customerName, List<Item> items)
        {
            OrderId = orderId;
            CustomerName = customerName;
            Items = items;
        }

        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public List<Item> Items { get; set; }
    }
}
