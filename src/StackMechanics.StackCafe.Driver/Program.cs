using System;
using Autofac;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Commands;
using StackMechanics.StackCafe.Infrastructure;

namespace StackMechanics.StackCafe.Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = IoC.LetThereBeIoC())
            {
                var customerId = Guid.NewGuid();
                var orderId = Guid.NewGuid();

                using (var scope = container.BeginLifetimeScope())
                {
                    var uow = scope.Resolve<IUnitOfWork>();
                    var mediator = scope.Resolve<IMediator>();

                    mediator.Send(new SignUpCustomerCommand(customerId, "Damian"));

                    uow.Complete();
                }

                using (var scope = container.BeginLifetimeScope())
                {
                    var uow = scope.Resolve<IUnitOfWork>();
                    var mediator = scope.Resolve<IMediator>();

                    mediator.Send(new CustomerPlaceOrderCommand(orderId, customerId,
                        new[] {new OrderItemDto("Flat white", 1)}));
                    mediator.Send(new CustomerPayForOrderCommand(customerId, orderId));

                    uow.Complete();
                }

                using (var scope = container.BeginLifetimeScope())
                {
                    var repository = scope.Resolve<IRepository<Customer>>();
                    var customer = repository.Get(customerId);

                    Console.WriteLine(customer.IsCaffeinated);
                }
            }
        }
    }
}
