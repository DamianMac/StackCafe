using Nimbus.MessageContracts;

namespace StackMechanics.MessageContracts.Events
{
    public class OrderPlacedEvent : IBusEvent
    {
        public OrderPlacedEvent()
        {
        }

        public OrderPlacedEvent(string coffeeType, string customerName)
        {
            CoffeeType = coffeeType;
            CustomerName = customerName;
        }

        public string CoffeeType { get; set; }
        public string CustomerName { get; set; }
    }
}