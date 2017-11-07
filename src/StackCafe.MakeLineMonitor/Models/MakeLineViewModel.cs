namespace StackCafe.MakeLineMonitor.Models
{
    public class MakeLineViewModel
    {
        public MakeLineViewModel(params Order[] items)
        {
            Items = items;
        }

        public Order[] Items { get; }
    }
}
