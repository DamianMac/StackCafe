namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate
{
    public class OrderItemDto
    {
        public OrderItemDto(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}