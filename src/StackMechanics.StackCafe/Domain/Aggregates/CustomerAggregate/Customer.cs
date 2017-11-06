using System;
using System.Collections.Generic;

namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate
{
    public class Customer
    {
        public Guid CustomerId { get; }
        public string Name { get; }
        public List<Order> Orders { get; } = new List<Order>();

        private Customer(Guid customerId, string name)
        {
            CustomerId = customerId;
            Name = name;
        }

        public static Customer SignUp(Guid customerId, string name)
        {
            return new Customer(customerId, name);
        }

        public Order PlaceOrder(Guid orderId, OrderItem[] orderItems)
        {
            var order = new Order(orderId, orderItems);
            Orders.Add(order);
            return order;
        }
    }
}