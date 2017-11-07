using Nimbus.Handlers;
using StackCafe.MessageContracts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCafe.Cashier.Rules.WhenACustomerPaysForTheirOrder
{
    public class CheckWhetherItHasAlreadyBeenMade : IHandleCompetingEvent<OrderPaidForEvent>

    {
        public Task Handle(OrderPaidForEvent busEvent)
        {
            //throw new NotImplementedException();
            return Task.CompletedTask;
        }
    }
}
