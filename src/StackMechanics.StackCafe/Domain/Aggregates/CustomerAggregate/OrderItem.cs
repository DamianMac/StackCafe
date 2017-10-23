namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate
{
    public class OrderItem
    {
        public OrderItem(string itemName, int quantity)
        {
            ItemName = itemName;
            Quantity = quantity;
        }

        public string ItemName { get; }
        public int Quantity { get; }
    }
}