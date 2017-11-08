using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Commands
{
    public class MakeCoffeeCommand : IBusCommand
    {
        public MakeCoffeeCommand()
        {
        }

        public MakeCoffeeCommand(Guid orderId, string coffeeType, string customerName)
        {
            OrderId = orderId;
            CoffeeType = coffeeType;
            CustomerName = customerName;
        }

        public Guid OrderId { get; set; }
        public string CoffeeType { get; set; }
        public string CustomerName { get; set; }
    }
}
