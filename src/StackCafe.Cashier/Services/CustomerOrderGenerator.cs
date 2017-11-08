using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Nimbus;
using StackCafe.MessageContracts;
using StackCafe.MessageContracts.Commands;

namespace StackCafe.Cashier.Services
{
    internal class FakeOrderItem
    {
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public ItemType Type { get; set; }
    }

    public class CustomerOrderGenerator : IDisposable
    {
        private static readonly double _interval = TimeSpan.FromSeconds(5).TotalMilliseconds;
        private static readonly string[] _customerNames = {"Damian", "Nick", "Andrew", "Jared", "Josh", "Andrew" ,"Billy", "Bob", "James"};

        private static List<FakeOrderItem> _fakeOrderItems = new List<FakeOrderItem>();

        private readonly IBus _bus;
        private readonly Random _random = new Random();

        private Timer _timer;

        public CustomerOrderGenerator(IBus bus)
        {
            _bus = bus;
            AddFakeOrderItem("Extra Shot Flat White", "ESFW", ItemType.Drink);
            AddFakeOrderItem("Cappuccino", "CPPU", ItemType.Drink);
            AddFakeOrderItem("Carajillo", "CRJL", ItemType.Drink);
            AddFakeOrderItem("Cortado", "CRTD", ItemType.Drink);
            AddFakeOrderItem("Cuban Espresso", "CBES", ItemType.Drink);
            AddFakeOrderItem("Espresso", "ESPR", ItemType.Drink);
            AddFakeOrderItem("Eiskaffee", "ESFE", ItemType.Drink);
            AddFakeOrderItem("The Flat White", "TFWT", ItemType.Drink);
            AddFakeOrderItem("Frappuccino", "FRPC", ItemType.Drink);
            AddFakeOrderItem("Galao", "GLAO", ItemType.Drink);
            AddFakeOrderItem("Iced-Coffee", "ICCF", ItemType.Drink);
            AddFakeOrderItem("Irish Coffee", "IRCF", ItemType.Drink);
            AddFakeOrderItem("Liqueur Coffee", "LQCF", ItemType.Drink);

            AddFakeOrderItem("Artichoke Frittata Panini", "ACFP", ItemType.Food);
            AddFakeOrderItem("Spinach and Feta Quiche", "SFQE", ItemType.Food);
            AddFakeOrderItem("Breakfast Pizza", "BFPZ", ItemType.Food);
            AddFakeOrderItem("Ham and Swiss Gruyere Quiche", "HSGQ", ItemType.Food);
            AddFakeOrderItem("Nectarine Mascarpone French Toast Panini", "NMST", ItemType.Food);
            AddFakeOrderItem("Specialty Bread Sample Plate", "SBSP", ItemType.Food);
            AddFakeOrderItem("Smoked Salmon Platter", "SSPT", ItemType.Food);
            AddFakeOrderItem("Steel Cut Oatmeal", "STOM", ItemType.Food);
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

            var coffees = _fakeOrderItems.Where(oi => oi.Type == ItemType.Drink).ToArray();
            var coffee = coffees[_random.Next(coffees.Length)];

            var foods = _fakeOrderItems.Where(oi => oi.Type == ItemType.Food).ToArray();
            var food = foods[_random.Next(foods.Length)];
            var coffeePrepTime = _random.Next(1, 10);
            var foodPrepTime = _random.Next(1, 10);

            var itemsToSend = new List<Item>
            {
                new Item
                {
                    ItemName = coffee.ItemName,
                    ItemCode = coffee.ItemCode,
                    ItemPrepTime = coffeePrepTime,
                    ItemType = coffee.Type.ToString()
                },
                new Item
                {
                    ItemName = food.ItemName,
                    ItemCode = food.ItemCode,
                    ItemPrepTime = foodPrepTime,
                    ItemType = food.Type.ToString()
                }
            };

            var orderId = Guid.NewGuid();
            var command = new PlaceOrderCommand(orderId, customer, itemsToSend);
            await _bus.Send(command);

            var foodCommand = new PlaceFoodOrderCommand(orderId, itemsToSend.Where(i => i.ItemType == ItemType.Food.ToString()).ToList());
            await _bus.Send(foodCommand);

            var drinkCommand = new PlaceDrinkOrderCommand(orderId, itemsToSend.Where(i => i.ItemType == ItemType.Drink.ToString()).ToList());
            await _bus.Send(drinkCommand);
        }

        private static void AddFakeOrderItem(string name, string code, ItemType type)
        {
            _fakeOrderItems.Add(new FakeOrderItem
            {
                ItemCode = code,
                ItemName = name,
                Type = type
            });
        }
    }
}
