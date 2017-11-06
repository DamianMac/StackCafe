using System;
using NUnit.Framework;
using Shouldly;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate;

namespace StackMechanics.StackCafe.Tests.Unit
{
    public class GivenASignedUpCustomer_WhenACustomerPlacesAnOrder : BddTest
    {
        private Customer _customer;
        private readonly Guid _customerId = Guid.NewGuid();
        private Order _order;
        private readonly Guid _orderId = Guid.NewGuid();
        private OrderItem[] _orderItems;

        protected override void Given()
        {
            _customer = Customer.SignUp(_customerId, "Damian");
        }

        protected override void When()
        {
            _orderItems = new[] {new OrderItem("Flat white", 1)};
            _order = _customer.PlaceOrder(_orderId, _orderItems);
        }

        [Test]
        public void TheCustomerShouldHaveAnOrder()
        {
            _customer.Orders.ShouldHaveSingleItem();
        }

        [Test]
        public void TheOrderShouldContainTheCorrectItems()
        {
            _order.Items.Length.ShouldBe(1);
        }
    }
}
