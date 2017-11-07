using Autofac;
using Nimbus;
using Serilog;
using StackCafe.Common.Logging;
using System;
using System.Linq;

namespace StackCafe.Customer
{
    internal class CustomerService
    {
        private IContainer _container;
        private readonly IBus _bus;
        private readonly Random _random = new Random();

        public CustomerService()
        {
        }
        public void Start()
        {
            Log.Logger = DefaultLoggerConfiguration.CreateLogger();

            try
            {
                _container = IoC.LetThereBeIoC();
                            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An unhandled exception occurred");
                Log.CloseAndFlush();
                throw;
            }
        }

        public void Stop()
        {
            _container?.Dispose();
            Log.CloseAndFlush();
        }

        //public async Task Run(Func<Task> action, CancellationToken cancellationToken)
        //{
        //    while (!cancellationToken.IsCancellationRequested)
        //    {
        //        var delayTicks = TimeSpan.FromTicks(_random.Next((int)TimeSpan.FromSeconds(15).Ticks));
        //        await Task.Delay(delayTicks, cancellationToken);

        //        if (!cancellationToken.IsCancellationRequested)
        //            await action();
        //    }
        //}

        //private static readonly string[] _coffeeOrders = { "Extra shot flat white", "Doppio", "Flat white" };
        //private async Task OrderCoffee()
        //{
        //    
        //}
    }
}
