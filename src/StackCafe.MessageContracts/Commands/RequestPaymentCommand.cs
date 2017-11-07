using Nimbus.MessageContracts;
using System;

namespace StackCafe.MessageContracts.Commands
{
    public class RequestPaymentCommand: IBusCommand
    {
        public RequestPaymentCommand(Guid orderId, decimal price)
        {
            Price = price;
            OrderId = orderId;
        }

        public Guid OrderId { get; set; }
        public decimal Price { get; set; }
    }
}