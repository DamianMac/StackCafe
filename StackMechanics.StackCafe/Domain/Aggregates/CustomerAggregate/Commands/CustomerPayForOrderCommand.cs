using System;
using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Commands
{
    public class CustomerPayForOrderCommand : ICommand
    {
        public CustomerPayForOrderCommand(Guid customerId, Guid orderId)
        {
            CustomerId = customerId;
            OrderId = orderId;
        }

        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
    }
}