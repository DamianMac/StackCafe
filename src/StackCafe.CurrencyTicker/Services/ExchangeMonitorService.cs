using System;
using System.Threading.Tasks;
using System.Timers;
using Nimbus;
<<<<<<< HEAD
using StackCafe.MessageContracts.Commands;
using StackCafe.CurrencyTicker.Services.Coindesk;
using System.Net;
=======
using StackCafe.MessageContracts.Events;
>>>>>>> ee0f4f9e4c12492bd515dd58b6905bd5fa1c84bf

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
            var timer = (Timer)sender;
#pragma warning disable 4014
            var price = GetThePrice();
            LetEveryoneKnowTheCurrentPrice(price);
#pragma warning restore 4014
            timer.Interval = 1;
            timer.Enabled = true;
        }



        private const string ApiEndpoint = "https://api.coindesk.com/v1/bpi/currentprice/{0}.json";
        private const string Aud = "AUD";

        private async decimal GetThePrice()
        {
            var endpointUrl = string.Format(ApiEndpoint, Aud);

            var webClient = new WebClient();

            var apiResponse = await webClient.DownloadStringTaskAsync(endpointUrl);

            var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<CoindeskApiResponseObject>(apiResponse);
            return new CurrencyExchangeRate((decimal)(_random.NextDouble() * 0.001), Currency.BTC);
        }

        private async Task LetEveryoneKnowTheCurrentPrice(CurrencyExchangeRate price)
        {
            var @event = new CurrencyExchangeRateEvent(price);
            await _bus.Publish(@event);
        }
    }


}