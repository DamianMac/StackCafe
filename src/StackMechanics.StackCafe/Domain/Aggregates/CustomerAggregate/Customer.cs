using System;
using System.Collections.Generic;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Events;
using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate
{
    public class Customer : AggregateRoot
    {
        private Customer(Guid id, string name) : base(id)
        {
            Name = name;

            Orders = new List<Order>();
        }

        public string Name { get; }
        public bool IsCaffeinated { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Order PlaceOrder(Guid orderId, OrderItem[] items)
        {
            var order = new Order(orderId, this, items);
            Orders.Add(order);
            return order;
        }

        public static Customer SignUp(Guid id, string name)
        {
            var customer = new Customer(id, name);
            customer.DomainEvents.Raise(new CustomerSignedUpEvent(customer));

            return customer;
        }

        public void PayFor(Order order)
        {
            if (order.Customer != this) throw new DomainException("Customers generally only pay for their own orders");
            //TODO: We might want to change this. Can we pay for other customers' orders?
            //TODO: Do I have enough cash?

            order.MarkAsPaidBy(this);
        }

        public void AcceptDeliveryOfOrder(Order order)
        {
            if (order.Customer != this) throw new DomainException("Sorry! That's not my order.");

            IsCaffeinated = true;

            DomainEvents.Raise(new CustomerReceivedOrderEvent(order));
        }
    }
}