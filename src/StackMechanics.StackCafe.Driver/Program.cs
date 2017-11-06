using System;
using System.Runtime.Remoting.Messaging;
using Autofac;
using Serilog;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Commands;
using StackMechanics.StackCafe.Infrastructure;

namespace StackMechanics.StackCafe.Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.Seq("http://localhost:5341")
                .Enrich.WithProperty("Application","Stack cafe")
                .CreateLogger();
            Log.Information("Starting Up");

            try
            {
                using (var container = IoC.LetThereBeIoC())
                {
                    var customerId = Guid.NewGuid();
                    var orderId = Guid.NewGuid();

                    SignUpCustomer(container, customerId);
                    PlaceOrder(container, customerId, orderId);
                    CheckCaffinationStatus(container, customerId);
                    
                }
            }
            catch (Exception exception)
            {
                Log.Fatal(exception,"unhandled exception");
            }
           
            Log.CloseAndFlush();
        }

        private static void CheckCaffinationStatus(IContainer container, Guid customerId)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var repository = scope.Resolve<IRepository<Customer>>();
                var customer = repository.Get(customerId);

                Console.WriteLine(customer.IsCaffeinated);
                
            }
        }

        private static void PlaceOrder(IContainer container, Guid customerId, Guid orderId)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var uow = scope.Resolve<IUnitOfWork>();
                var mediator = scope.Resolve<IMediator>();

                mediator.Send(new CustomerPlaceOrderCommand(orderId, customerId,
                    new[] { new OrderItemDto("Flat white", 1) }));
                mediator.Send(new CustomerPayForOrderCommand(customerId, orderId));

                uow.Complete();
            }
        }

        private static void SignUpCustomer(IContainer container, Guid customerId)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                Log.Information("Signing up customer {CustomerID}", customerId);
                var uow = scope.Resolve<IUnitOfWork>();
                var mediator = scope.Resolve<IMediator>();

                mediator.Send(new SignUpCustomerCommand(customerId, "Damian"));

                uow.Complete();
            }
        }
    }
}
