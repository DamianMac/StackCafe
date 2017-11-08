using Nimbus.Handlers;
using StackCafe.MakeLineMonitor.Services;
using StackCafe.MessageContracts.Events;
using System.Threading.Tasks;

namespace StackCafe.Waiter.Rules.WhenAnOrderIsPaidFor
{
    public class AddItToRunningTotal : IHandleCompetingEvent<OrderPaidForEvent>
    {


        readonly IAccountingService accountingService;
        public AddItToRunningTotal(IAccountingService accountingService)
        {
            this.accountingService = accountingService;
        }
        
        public async Task Handle(OrderPaidForEvent busEvent)
        {
            accountingService.Add(busEvent.OrderId, busEvent.Amount);
        }
    }
}