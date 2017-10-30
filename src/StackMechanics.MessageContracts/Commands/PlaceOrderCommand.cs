using Nimbus.MessageContracts;

namespace StackMechanics.MessageContracts.Commands
{
    public class PlaceOrderCommand : IBusCommand
    {
        public PlaceOrderCommand()
        {
        }

        public PlaceOrderCommand(string customerName, string coffeeType)
        {
            CustomerName = customerName;
            CoffeeType = coffeeType;
        }

        public string CustomerName { get; set; }
        public string CoffeeType { get; set; }
    }
}