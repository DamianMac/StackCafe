using System;
using System.Linq;
using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using ILogger = Serilog.ILogger;
using StackCafe.MessageContracts.Commands;
using StackCafe.MessageContracts.Events;

namespace StackCafe.Chef.Rules.WhenAFoodItemIsPlaced
{
    public class PrepareTheFoodItem : IHandleCommand<PlaceFoodOrderCommand>
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;

        public PrepareTheFoodItem(IBus bus, ILogger logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public async Task Handle(PlaceFoodOrderCommand busCommand)
        {
            if (busCommand.Items == null || !busCommand.Items.Any())
            {
                throw new Exception("Recieved command containing no food items");
            }

            // TODO: support multiple food items
            var foodItem = busCommand.Items.First();
            _logger.Information("Preparing food item {Food} for order {OrderId}, this will take {FoodPrepTime} seconds", foodItem.ItemCode, busCommand.OrderId, foodItem.ItemPrepTime);
            await Task.Delay(TimeSpan.FromSeconds(foodItem.ItemPrepTime));
            _logger.Information("Food item {Food} for order {OrderId} has been prepared", foodItem.ItemCode, busCommand.OrderId);

            var orderItemComplete = new OrderItemCompleteEvent
            {
                OrderId = busCommand.OrderId,
                ItemCode = foodItem.ItemCode
            };

            await _bus.Publish(orderItemComplete);
        }
    }
}
