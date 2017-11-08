using System;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Events
{
    public class OrderPlacedEvent : IBusEvent
    {

        public OrderPlacedEvent()
        {
        }

        public OrderPlacedEvent(Guid orderId, string coffeeType, string customerName, string customerPhoneNumber)
        {
            CustomerPhoneNumber = customerPhoneNumber;
            OrderId = orderId;
            CoffeeType = coffeeType;
            CustomerName = customerName;
        }

        public string CustomerPhoneNumber { get; set; }

        public Guid OrderId { get; set; }
        public string CoffeeType { get; set; }
        public string CustomerName { get; set; }
    }
}