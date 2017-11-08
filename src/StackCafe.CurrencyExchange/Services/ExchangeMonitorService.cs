using System;
using System.Threading.Tasks;
using System.Timers;
using Nimbus;
using StackCafe.MessageContracts.Commands;

namespace StackCafe.CurrencyTicker.Services
{
    public class ExchangeMonitorService : IDisposable
    {
        private readonly IBus _bus;
        private readonly Random _random = new Random();

        private Timer _timer;

        public ExchangeMonitorService(IBus bus)
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
            var price = GetThePrice();
            LetEveryoneKnowTheCurrentPrice(price);
#pragma warning restore 4014
            timer.Interval = 1;
            timer.Enabled = true;
        }

        private decimal GetThePrice()
        {
            return 1;
        }

        private async Task LetEveryoneKnowTheCurrentPrice()
        {
            var customer = _customerNames[_random.Next(_customerNames.Length)];
            var coffee = _coffeeOrders[_random.Next(_coffeeOrders.Length)];
            var command = new PlaceOrderCommand(Guid.NewGuid(), customer, coffee);
            await _bus.Send(command);
        }
    }
}