using System;
using System.Linq;
using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Commands;
using StackCafe.MessageContracts.Events;
using ILogger = Serilog.ILogger;

namespace StackCafe.Barista.Rules.WhenADrinkItemIsPlaced
{
    public class PrepareTheDrinkItem : IHandleCommand<PlaceDrinkOrderCommand>
    {

        private readonly IBus _bus;
        private readonly ILogger _logger;

        public PrepareTheDrinkItem(IBus bus, ILogger logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public async Task Handle(PlaceDrinkOrderCommand busCommand)
        {
            if (busCommand.Items == null || !busCommand.Items.Any())
            {
                throw new Exception("Recieved command containing no drink items");
            }

            // TODO: support multiple food items
            var drinkItem = busCommand.Items.First();
            _logger.Information("Preparing drink item {Drink} for order {OrderId}, this will take {DrinkPrepTime} seconds", drinkItem.ItemCode, busCommand.OrderId, drinkItem.ItemPrepTime);
            await Task.Delay(TimeSpan.FromSeconds(drinkItem.ItemPrepTime));
            _logger.Information("Drink item {Drink} for order {OrderId} has been prepared", drinkItem.ItemCode, busCommand.OrderId);

            var orderItemComplete = new OrderItemCompleteEvent
            {
                OrderId = busCommand.OrderId,
                ItemCode = drinkItem.ItemCode
            };

            await _bus.Publish(orderItemComplete);
        }
    }
}