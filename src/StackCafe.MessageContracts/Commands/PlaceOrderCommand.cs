using System;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Commands
{
    public class PlaceOrderCommand : IBusCommand
    {
        public PlaceOrderCommand()
        {
        }

        public PlaceOrderCommand(Guid orderId, string customerName, string[] items)
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