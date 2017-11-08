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
            _timer.Interval = 10000;
            _timer.Enabled = true;
        }

        private async void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            var timer = (Timer)sender;
#pragma warning disable 4014
            foreach (Currency currency in Enum.GetValues(typeof(Currency)))
            {
                if (currency != Currency.BTC)
                {
                    try
                    {
                        var price = await GetThePrice(currency);
                        LetEveryoneKnowTheCurrentPrice(price);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            }
#pragma warning restore 4014
            timer.Interval = 10000;
            timer.Enabled = true;
        }



        private const string ApiEndpoint = "https://api.coindesk.com/v1/bpi/currentprice/{0}.json";


        private async Task<CurrencyExchangeRate> GetThePrice(Currency currencyCode)
        {
            var endpointUrl = string.Format(ApiEndpoint, currencyCode);
            string apiResponse;
            using (var webClient = new WebClient())
            {
                apiResponse = await webClient.DownloadStringTaskAsync(endpointUrl);
            }
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