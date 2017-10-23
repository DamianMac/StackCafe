using System;
using Autofac;
using NUnit.Framework;
using Shouldly;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Commands;
using StackMechanics.StackCafe.Infrastructure;

namespace StackMechanics.StackCafe.Tests.Integration
{
    public class WhenACustomerPlacesAndPaysForAnOrder
    {
        [Test]
        public void TheCustomerShouldEndUpCaffeinated()
        {
            var container = IoC.LetThereBeIoC();

            var customerId = Guid.NewGuid();
            var orderId = Guid.NewGuid();

            using (var scope = container.BeginLifetimeScope())
            {
                var uow = scope.Resolve<IUnitOfWork>();
                var mediator = scope.Resolve<IMediator>();

                mediator.Send(new SignUpCustomerCommand(customerId, "Damian"));
                mediator.Send(new CustomerPlaceOrderCommand(orderId, customerId, new[] {new OrderItemDto("Flat white", 1)}));
                mediator.Send(new CustomerPayForOrderCommand(customerId, orderId));

                uow.Complete();
            }

            using (var scope = container.BeginLifetimeScope())
            {
                var repository = scope.Resolve<IRepository<Customer>>();
                var customer = repository.Get(customerId);

                customer.IsCaffeinated.ShouldBeTrue();
            }
        }
    }
}