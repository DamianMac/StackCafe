using System;
using System.Collections;
using System.Collections.Generic;

namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate
{
    public class Customer
    {
        public Customer()
        {
                
        }
        public static Customer SignUp(Guid guid, string name)
        {
            var customer = new Customer() { Name = name, Guid = guid };
            return customer;
        }
        public Order PlaceOrder(Guid guid, OrderItem[] orderItem)
        {
            var order = new Order(guid, orderItem);
            Orders.Add(order);
            return order;
        }

        public List<Order> Orders { get; set; } = new List<Order>();
        public string Name { get; set; }
        public Guid Guid { get; set; }
    }
}