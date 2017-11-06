using System;
using Serilog;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Events;
using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate
{
    public class Order : Entity
    {
        public Order(Guid id, Customer customer, OrderItem[] items) : base(id, customer)
        {
            Customer = customer;
            Items = items;

            IsPaid = false;
            IsReady = false;
        }

        public Customer Customer { get; }
        public OrderItem[] Items { get; }

        public bool IsPaid { get; private set; }
        public bool IsReady { get; set; }

        public void MarkAsPaidBy(Customer customer)
        {
            //TODO check preconditions

            IsPaid = true;
            Log.Information("Customer {CustomerId} Has Paid the order {OrderID}",Customer.Id,this.Id);
            DomainEvents.Raise(new OrderPaidForEvent(customer, this));
        }

        public void MarkAsReady()
        {
            //TODO check preconditions

            IsReady = true;
            Log.Information(" Order {OrderID} is ready",this.Id);
            DomainEvents.Raise(new OrderIsReadyEvent(this));
        }
    }
}