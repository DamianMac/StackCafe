namespace StackCafe.MakeLineMonitor.Models
{
    public class MakeLineViewModel
    {
        public MakeLineViewModel(params OrderItemViewModel[] items)
        {
            Items = items;
        }

        public OrderItemViewModel[] Items { get; }
    }

    public class OrderItemViewModel
    {
        public string Name { get; set; }
        public bool WasRecommended { get; set; }
    }
}