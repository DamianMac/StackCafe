using Nimbus.Handlers;
using StackCafe.MessageContracts.Events;
using System.Threading.Tasks;

namespace StackCafe.Waiter.Rules.WhenAnOrderIsPaidFor
{
    public class AddItToRunningTotal : IHandleCompetingEvent<OrderPaidForEvent>
    {
      

        public AddItToRunningTotal()
        {
        }

        public CurrencyAmount Aud { get; set; }
        public async Task Handle(OrderPaidForEvent busEvent)
        {
            //busEvent.Amnount.
        }
    }
}