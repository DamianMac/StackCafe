using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Nimbus;
using StackCafe.MessageContracts.Commands;
using StackCafe.MessageContracts.Requests;

namespace StackCafe.Cashier.Services
{
    public class CustomerOrderGenerator : IDisposable
    {
        private static double _interval = TimeSpan.FromSeconds(5).TotalMilliseconds;
        private static readonly string[] _customerNames = {"Damian", "Nick", "Andrew", "Yann", "Minna", "Terry"};
        private static readonly string[] _coffeeOrders = {"Extra shot flat white", "Doppio", "Flat white", "Muffin (Chocolate)", "Bliss Ball", "Toastie", "Big Biscuit", "Mocha", "Croissant" };

        private readonly IBus _bus;
        private readonly Random _random = new Random();

        private Timer _timer;
        private IRecommendationService _recommendationService;

        public CustomerOrderGenerator(IBus bus, IRecommendationService recommendationService)
        {
            _bus = bus;
            _recommendationService = recommendationService;
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
            _interval = TimeSpan.FromSeconds(_random.Next(1, 10)).TotalMilliseconds;
            timer.Interval = _interval;
            timer.Enabled = true;
        }

        private async Task PlaceFakeOrder()
        {
            var customer = _customerNames[_random.Next(_customerNames.Length)];

            var items = new List<string>();
            for (var i = 0; i < _random.Next(1, 5); i++)
            {
                var coffee = _coffeeOrders[_random.Next(_coffeeOrders.Length)];
                items.Add(coffee);
            }

            await UpdateWithRecommendation(customer, items);

            var command = new PlaceOrderCommand(Guid.NewGuid(), customer, items.ToArray());
            await _bus.Send(command);
        }

        private async Task UpdateWithRecommendation(string customer, List<string> items)
        {
            //var recommendation = await _bus.Request(new RecommendationRequest(customer, items));
            var recommendations = await _recommendationService.AskForRecommendations(customer, items);
            if (recommendations.Any())
            {
                var response = await _bus.Request(
                    new RecommendationRequest() {Customer = customer, RecommendedItems = recommendations});
                if (response.IsAccepted)
                    items.AddRange(recommendations);
            }
        }
    }
}