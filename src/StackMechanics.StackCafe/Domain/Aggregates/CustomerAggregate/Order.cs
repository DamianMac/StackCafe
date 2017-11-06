using System;
using System.Collections.Generic;

namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Order(Guid OrderId, OrderItem[] items)
        {
            Items = items;
        }
        public OrderItem[] Items { get;}
    }
}