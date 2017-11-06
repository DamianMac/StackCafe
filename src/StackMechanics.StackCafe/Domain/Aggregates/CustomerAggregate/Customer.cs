using System;
using System.Collections.Generic;

namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate
{
    public class Customer

    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; }
        public Customer(string name, Guid customerId)
        {
            Orders = new List<Order>();
        }
        public static Customer SignUp(Guid customerId, string damian)
        {
            return new Customer(damian, customerId);

        }

        public Order PlaceOrder(Guid orderId, OrderItem[] orderItems)
        {
            return  new Order(orderId,orderItems);
        }


    }
}