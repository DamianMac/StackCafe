using System;
using System.Threading.Tasks;
using System.Timers;
using Nimbus;
using StackCafe.MessageContracts.Commands;
using StackCafe.MessageContracts.Events;

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

        private CurrencyAmount GetThePrice()
        {
            return new CurrencyAmount((decimal)(_random.NextDouble() * 0.001), Currency.BTC);
        }

        private async Task LetEveryoneKnowTheCurrentPrice(CurrencyAmount price)
        {
            var @event = new CurrentPriceEvent(price);
            await _bus.Publish(@event);
        }
    }
}