using System;
using System.Threading.Tasks;
using System.Timers;
using Nimbus;
using StackCafe.MessageContracts.Commands;
using StackCafe.Cashier.Ef;
using System.Linq;
using Serilog;

namespace StackCafe.Cashier.Services
{
    public class CustomerOrderGenerator : IDisposable
    {
        private static readonly double _interval = TimeSpan.FromSeconds(5).TotalMilliseconds;
        private static readonly string[] _customerNames = {"Damian", "Nick", "Andrew"};
        private static readonly string[] _coffeeOrders = {"Extra shot flat white", "Doppio", "Flat white"};

        private readonly IBus _bus;
        private readonly Random _random = new Random();

        private Timer _timer;

        public CustomerOrderGenerator(IBus bus)
        {
            _bus = bus;
        }

        public void Dispose()
        {
            _timer?.Stop();
        }

        public void Start()
        {
            _timer = new Timer();
            _timer.Elapsed += OnTimerElapsed;
            _timer.Interval = 1;
            _timer.Enabled = true;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            var timer = (Timer) sender;
#pragma warning disable 4014
            PlaceFakeOrder();
#pragma warning restore 4014
            timer.Interval = _interval;
            timer.Enabled = true;
        }

        private async Task PlaceFakeOrder()
        {
            try
            {
                var rnd = new Random();
                using (var dbcontext = new CustomerDbContext())
                {
                    var customerCount = dbcontext.Customers.Count();
                    var customerNumber = rnd.Next(customerCount);

                    var customer = dbcontext.Customers.OrderBy(c=>c.Name).Skip(customerNumber).Take(1).SingleOrDefault();

                    if (customer != null)
                    {
                        var coffee = _coffeeOrders[_random.Next(_coffeeOrders.Length)];
                        var command = new PlaceOrderCommand(Guid.NewGuid(), customer.Id, customer.Name, coffee);
                        await _bus.Send(command);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "unhandled exception");
            }
            //var customer = _customerNames[_random.Next(_customerNames.Length)];
            //var coffee = _coffeeOrders[_random.Next(_coffeeOrders.Length)];
            //var command = new PlaceOrderCommand(Guid.NewGuid(), customer, coffee);
            //await _bus.Send(command);
        }
    }
}