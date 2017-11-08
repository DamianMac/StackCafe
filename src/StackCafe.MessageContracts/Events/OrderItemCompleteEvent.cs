using System;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Events
{
    public class OrderItemCompleteEvent : IBusEvent
    {
        public Guid OrderId { get; set; }

        public string ItemCode { get; set; }
    }
}