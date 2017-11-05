using System;
using Autofac;
using NUnit.Framework;
using Shouldly;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Commands;
using StackMechanics.StackCafe.Infrastructure;

namespace StackMechanics.StackCafe.Tests.Integration
{
    public class WhenACustomerPlacesAndPaysForAnOrder : BddTest
    {
        private IContainer _container;
        private Guid _customerId;
        private Guid _orderId;

        protected override void Given()
        {
            _container = IoC.LetThereBeIoC();

            _customerId = Guid.NewGuid();
            _orderId = Guid.NewGuid();

            using (var scope = _container.BeginLifetimeScope())
            {
                var uow = scope.Resolve<IUnitOfWork>();
                var mediator = scope.Resolve<IMediator>();

                mediator.Send(new SignUpCustomerCommand(_customerId, "Damian"));

                uow.Complete();
            }
        }

        protected override void When()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var uow = scope.Resolve<IUnitOfWork>();
                var mediator = scope.Resolve<IMediator>();

                mediator.Send(new CustomerPlaceOrderCommand(_orderId, _customerId, new[] {new OrderItemDto("Flat white", 1)}));
                mediator.Send(new CustomerPayForOrderCommand(_customerId, _orderId));

                uow.Complete();
            }
        }

        [Test]
        public void TheCustomerShouldEndUpCaffeinated()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var repository = scope.Resolve<IRepository<Customer>>();
                var customer = repository.Get(_customerId);

                customer.IsCaffeinated.ShouldBeTrue();
            }
        }
    }
}