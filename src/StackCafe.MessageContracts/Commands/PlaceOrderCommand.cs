using System;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Commands
{
    public class PlaceOrderCommand : IBusCommand
    {
        public PlaceOrderCommand()
        {
        }

        public PlaceOrderCommand(Guid orderId, string customerName, string coffeeType, string phoneNumber)
        {
            OrderId = orderId;
            CustomerName = customerName;
            CoffeeType = coffeeType;
            PhoneNumber = phoneNumber;
        }

        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CoffeeType { get; set; }
        public string PhoneNumber { get; set; }
    }
}