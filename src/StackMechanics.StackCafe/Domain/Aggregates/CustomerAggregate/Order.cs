using System;
using System.Collections.Generic;

namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate
{
    public class Order
    {
        public Guid OrderId { get; }
        public OrderItem[] Items { get; }

        public Order(Guid orderId, OrderItem[] orderItems)
        {
            OrderId = orderId;
            Items = orderItems;
        }
    }
}