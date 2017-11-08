using System.Linq;
using System.Threading.Tasks;
using Nimbus.Handlers;
using StackCafe.Cashier.Services;
using StackCafe.MessageContracts.Events;

namespace StackCafe.Cashier.Rules.WhenACustomerPlacesAnOrder
{
    public class StoreOrderForRecommendation : IHandleMulticastEvent<OrderPlacedEvent>
    {
        private readonly IOrderHistory _orderStorage;

        public StoreOrderForRecommendation(IOrderHistory orderStorage)
        {
            _orderStorage = orderStorage;
        }

        public Task Handle(OrderPlacedEvent busEvent)
        {
            _orderStorage.AddOrder(busEvent.CustomerName, busEvent.Items.Select(item => item.Name).ToArray());
            return Task.CompletedTask;
        }
    }
}