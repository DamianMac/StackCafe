using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using Nimbus;
using StackCafe.MessageContracts;
using StackCafe.MessageContracts.Commands;
using StackCafe.MessageContracts.Events;

namespace StackCafe.Cashier.Services
{
    public class CustomerOrderGenerator : IDisposable
    {
        private static readonly double _interval = TimeSpan.FromSeconds(5).TotalMilliseconds;
        private static readonly string[] _customerNames = {"Damian", "Nick", "Andrew", "Jared", "Josh", "Andrew" ,"Billy", "Bob", "James"};

        private static List<string> _coffeeOrders = new List<string>();
        private static List<string> _foodOrders = new List<string>();

        private readonly IBus _bus;
        private readonly Random _random = new Random();

        private Timer _timer;

        public CustomerOrderGenerator(IBus bus)
        {
            _bus = bus;

            _coffeeOrders.Add("Extra Shot Flat White");
            _coffeeOrders.Add("Cappuccino");
            _coffeeOrders.Add("Carajillo");
            _coffeeOrders.Add("Cortado");
            _coffeeOrders.Add("Cuban espresso");
            _coffeeOrders.Add("Espresso");
            _coffeeOrders.Add("Eiskaffee");
            _coffeeOrders.Add("The Flat White");
            _coffeeOrders.Add("Frappuccino");
            _coffeeOrders.Add("Galao");
            _coffeeOrders.Add("Iced-coffee");
            _coffeeOrders.Add("Irish coffee");
            _coffeeOrders.Add("Liqueur coffee");

            _foodOrders.Add("Artichoke Frittata Panini");
            _foodOrders.Add("Spinach and Feta Quiche");
            _foodOrders.Add("Breakfast Pizza");
            _foodOrders.Add("Ham and Swiss Gruyere Quiche");
            _foodOrders.Add("Nectarine Mascarpone French Toast Panini");
            _foodOrders.Add("Specialty Bread Sample Plate");
            _foodOrders.Add("Smoked Salmon Platter");
            _foodOrders.Add("Steel Cut Oatmeal");
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
            var customer = _customerNames[_random.Next(_customerNames.Length)];
            var coffee = _coffeeOrders[_random.Next(_coffeeOrders.Count)];
            var food = _foodOrders[_random.Next(_foodOrders.Count)];
            var coffeePrepTime = _random.Next(1, 10);
            var foodPrepTime = _random.Next(1, 10);

            var itemsToSend = new List<Item>();
            itemsToSend.Add(new Item(){ItemName = coffee, ItemPrepTime = coffeePrepTime, ItemType = ItemType.Drink.ToString()});
            itemsToSend.Add(new Item() { ItemName = food, ItemPrepTime = foodPrepTime, ItemType = ItemType.Food.ToString()}
            );

            var command = new PlaceOrderCommand(Guid.NewGuid(), customer, itemsToSend);

            await _bus.Send(command);
        }
    }
}
