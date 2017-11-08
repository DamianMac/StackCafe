using System;
using System.Threading.Tasks;
using System.Timers;
using Nimbus;
using StackCafe.MessageContracts.Commands;
using StackCafe.CurrencyTicker.Services.Coindesk;
using System.Net;
using StackCafe.MessageContracts.Events;
using System.Linq;

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

        private async void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            var timer = (Timer)sender;
#pragma warning disable 4014
            var price = await GetThePrice(Currency.AUD);
            LetEveryoneKnowTheCurrentPrice(price);
#pragma warning restore 4014
            timer.Interval = 10000;
            timer.Enabled = true;
        }



        private const string ApiEndpoint = "https://api.coindesk.com/v1/bpi/currentprice/{0}.json";
        private Currency[] ExchangeRates = { Currency.AUD };

        private async Task<CurrencyExchangeRate> GetThePrice(Currency currencyCode)
        {           
            var endpointUrl = string.Format(ApiEndpoint, currencyCode);

            var webClient = new WebClient();

            var apiResponse = await webClient.DownloadStringTaskAsync(endpointUrl);

            var jObject = Newtonsoft.Json.Linq.JObject.Parse(apiResponse);

            var rate = (double)jObject.SelectToken(string.Format("bpi.{0}.rate_float", currencyCode));
            var time = (DateTimeOffset)jObject.SelectToken("time.updatedISO");
                       
            return new CurrencyExchangeRate((decimal)rate, Currency.BTC, currencyCode, time);
        }

        private async Task LetEveryoneKnowTheCurrentPrice(CurrencyExchangeRate price)
        {
            var @event = new CurrencyExchangeRateUpdatedEvent(price);
            await _bus.Publish(@event);
        }
    }


}