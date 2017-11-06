namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate
{
    public class OrderItem
    {
        public OrderItem(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public int Count { get; set; }
        public string Name { get; set; }
    }
}