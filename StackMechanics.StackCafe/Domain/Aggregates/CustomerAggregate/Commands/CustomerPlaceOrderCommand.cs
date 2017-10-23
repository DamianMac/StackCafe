using System;
using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Commands
{
    public class CustomerPlaceOrderCommand : ICommand
    {
        public CustomerPlaceOrderCommand(Guid orderId, Guid customerId, OrderItemDto[] items)
        {
            OrderId = orderId;
            CustomerId = customerId;
            Items = items;
        }

        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public OrderItemDto[] Items { get; set; }
    }
}