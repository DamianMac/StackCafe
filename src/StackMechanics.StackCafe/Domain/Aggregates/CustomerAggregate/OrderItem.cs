namespace StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate
{
    public class OrderItem
    {
        private string _food;
        private int _count;

        public OrderItem(string food, int count)
        {
            this._food = food;
            this._count = count;
        }
    }
}