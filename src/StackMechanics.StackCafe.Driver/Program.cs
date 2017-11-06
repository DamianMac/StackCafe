using System;
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
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Seq("http://localhost:5341")
                .Enrich.WithProperty("Application", "Stack Cafe")
                .CreateLogger();

            Log.Information("Starting up application");

            try
            {
                using (var container = IoC.LetThereBeIoC())
                {
                    var customerId = Guid.NewGuid();
                    var orderId = Guid.NewGuid();

                    SignUpCustomer(container, customerId);

                    PlaceOrder(container, customerId, orderId);

                    CheckCaffeinationStatus(container, customerId);

                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled Exception");
            }

            Log.CloseAndFlush();
        }

        private static void CheckCaffeinationStatus(IContainer container, Guid customerId)
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
                var uow = scope.Resolve<IUnitOfWork>();
                var mediator = scope.Resolve<IMediator>();

                mediator.Send(new SignUpCustomerCommand(customerId, "Damian"));

                uow.Complete();
            }
        }
    }
}
