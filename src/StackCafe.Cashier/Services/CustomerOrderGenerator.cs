using System;
using System.Threading.Tasks;
using System.Timers;
using Nimbus;
using StackCafe.MessageContracts.Commands;
using StackCafe.MessageContracts.Events;

namespace StackCafe.Cashier.Services
{
    public class CustomerOrderGenerator : IDisposable
    {
        private static readonly double _interval = TimeSpan.FromSeconds(5).TotalMilliseconds;
        private static readonly string[] _customerNames = { "Damian", "Nick", "Andrew" };
        private static readonly string[] _coffeeOrders = { "Extra shot flat white", "Doppio", "Flat white" };

        private readonly IBus _bus;
        private readonly Random _random = new Random();

        private Timer _timer;
        private readonly Serilog.ILogger _logger;
        private readonly IBtcCurrencyConverterService _btcCurrencyConverterService;

        public CustomerOrderGenerator(IBus bus, Serilog.ILogger logger, IBtcCurrencyConverterService btcCurrencyConverterService)
        {
            _bus = bus;
            _logger = logger;
            _btcCurrencyConverterService = btcCurrencyConverterService;
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
            PlaceFakeOrder();
#pragma warning restore 4014
            timer.Interval = _interval;
            timer.Enabled = true;
        }

        private async Task PlaceFakeOrder()
        {
            var customer = _customerNames[_random.Next(_customerNames.Length)];
            var coffee = _coffeeOrders[_random.Next(_coffeeOrders.Length)];

            var orderId = Guid.NewGuid();
            var command = new PlaceOrderCommand(orderId, customer, coffee);
            await _bus.Send(command);

            CurrencyAmount amount;
            var currency = AskCustomerWhatCurrencyTheyWouldLike(); // mock pick random currency
            switch (currency)
            {
                case Currency.AUD:
                    amount = new CurrencyAmount(Currency.AUD, 3.00M);
                    break;
                case Currency.BTC:
                    var btc = _btcCurrencyConverterService.ConvertToBTC(3.00M);
                    amount = new CurrencyAmount(Currency.BTC, btc);
                    break;
                default:
                    throw new NotSupportedException();
            }         


            // for now, we'll pretend that we take the customer's money before actually adding the order to the queue
            _logger.Information("{Customer} just paid {Ammount} for their coffee. Thank you :)", customer, amount.Amount);
            await _bus.Publish(new OrderPaidForEvent(orderId, amount));

        }

        private Currency AskCustomerWhatCurrencyTheyWouldLike()
        {
            Random rnd = new Random();
            var randInt = rnd.Next(2);

            return randInt == 1 ? Currency.AUD : Currency.BTC;
        }
    }
}