using Nimbus;
using StackCafe.MessageContracts.Events;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace StackCafe.CurrencyTicker.Services
{
    public class ExchangeMonitorService : IDisposable
    {
        private readonly IBus _bus;
        private HttpClient _httpClient = new HttpClient();
        private System.Timers.Timer _timer;

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
            _timer = new System.Timers.Timer();
            _timer.Elapsed += OnTimerElapsed;
            _timer.Interval = 10000;
            _timer.Enabled = true;
        }

        private async void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            var timer = (System.Timers.Timer)sender;
#pragma warning disable 4014
            foreach (Currency currency in Enum.GetValues(typeof(Currency)))
            {
                if (currency != Currency.BTC)
                {
                    var price = await GetThePrice(currency);
                    LetEveryoneKnowTheCurrentPrice(price);
                }
            }
#pragma warning restore 4014
            timer.Interval = 100;
            timer.Enabled = true;
        }



        private const string ApiEndpoint = "https://api.coindesk.com/v1/bpi/currentprice/{0}.json";



        private volatile Task _throttle = Task.CompletedTask;



        TimeSpan GetRetryDelay(HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage.Headers.RetryAfter.Delta.HasValue)
            {
                return httpResponseMessage.Headers.RetryAfter.Delta.Value;
            }
            if (httpResponseMessage.Headers.RetryAfter.Date.HasValue)
            {
                return httpResponseMessage.Headers.RetryAfter.Date.Value - DateTimeOffset.Now;
            }
            return TimeSpan.FromSeconds(30);
        }
        private async Task<CurrencyExchangeRate> GetThePrice(Currency currencyCode)
        {
            var endpointUrl = string.Format(ApiEndpoint, currencyCode);
            string apiResponse;

            _throttle.Wait();

            var response = await _httpClient.GetAsync(endpointUrl);
            if (!response.IsSuccessStatusCode)
            {
                switch (response.StatusCode)
                {
                    case (HttpStatusCode)429:
                        var delay = GetRetryDelay(response);
                        Interlocked.Exchange(ref _throttle, Task.Delay(delay));
                        break;
                }
                return await GetThePrice(currencyCode);
            }
            apiResponse = await response.Content.ReadAsStringAsync();

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