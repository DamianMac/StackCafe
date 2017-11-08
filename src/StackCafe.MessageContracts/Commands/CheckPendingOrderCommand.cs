using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Commands
{
    public class CheckPendingOrderCommand : IBusCommand
    {
        public CheckPendingOrderCommand()
        {
        }

        public CheckPendingOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; set; }
    }
}
