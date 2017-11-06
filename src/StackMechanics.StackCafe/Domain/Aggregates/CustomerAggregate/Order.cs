using System;

namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate
{
    public class Order
    {
        private Guid guid;
        private OrderItem[] orderItem;

        public Order(Guid guid, OrderItem[] orderItem)
        {
            this.guid = guid;
            this.Items = orderItem;
        }

        public OrderItem[] Items
        { get => orderItem; set => orderItem = value; }
    }
}