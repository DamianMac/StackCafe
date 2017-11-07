using System;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Commands
{
    public class PlaceOrderCommand : IBusCommand
    {
        public PlaceOrderCommand()
        {
        }

        public PlaceOrderCommand(Guid orderId, Guid customerId, string customerName, string coffeeType)
        {
            CustomerId = customerId;
            OrderId = orderId;
            CustomerName = customerName;
            CoffeeType = coffeeType;
        }

        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CoffeeType { get; set; }
        public Guid CustomerId { get; set; }
    }
}