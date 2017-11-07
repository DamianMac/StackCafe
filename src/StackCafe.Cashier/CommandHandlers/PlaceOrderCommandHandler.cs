using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Commands;
using StackCafe.MessageContracts.Events;
using ILogger = Serilog.ILogger;
using StackCafe.Cashier.Ef;
using System.Linq;
using System.Diagnostics;

namespace StackCafe.Cashier.CommandHandlers
{
    public class PlaceOrderCommandHandler : IHandleCommand<PlaceOrderCommand>
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;

        public PlaceOrderCommandHandler(IBus bus, ILogger logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public async Task Handle(PlaceOrderCommand busCommand)
        {
            _logger.Information("{Customer} would like a {CoffeeType}", busCommand.CustomerName, busCommand.CoffeeType);
            await _bus.Publish(new OrderPlacedEvent(busCommand.OrderId, busCommand.CoffeeType, busCommand.CustomerName));

            using (var dbcontext = new CustomerDbContext())
            {
                var customer = dbcontext.Customers.Include("OrderHistory").Where(c => c.Id == busCommand.CustomerId).SingleOrDefault();
                if (customer == null)
                {
                    _logger.Error("Order received for unknown customer {@Customer} - {CustomerName}", busCommand.CustomerId, busCommand.CustomerName);
                    return;
                }

                Debug.Assert(!customer.OrderHistory.Any(o => o.Id == busCommand.OrderId));

                customer.OrderHistory.Add(new CustomerOrder() { Id = busCommand.OrderId, Coffee = busCommand.CoffeeType, Customer = customer });
                dbcontext.SaveChanges();
                if (IsDueFreebie(customer))
                {
                    _logger.Information("{Customer} is loyal and is getting a freebie :)", busCommand.CustomerName);
                    await _bus.Publish(new OrderPaidForEvent(busCommand.OrderId));
                }
                else
                {
                    _logger.Information("{Customer} is required to pay for coffee :)", busCommand.CustomerName);
                    var command = new RequestPaymentCommand(busCommand.OrderId, 15);
                    await _bus.Send(command);
                }                
            }            
        }

        private readonly int PaidCoffeesPerFreeCoffee = 9;
        private bool IsDueFreebie(Customer customer)
        {
            return customer.OrderHistory.Count % (PaidCoffeesPerFreeCoffee + 1) == PaidCoffeesPerFreeCoffee;
        }
    }
}