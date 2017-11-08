namespace StackCafe.MakeLineMonitor.Models
{
    public class MakeLineItemsViewModel
    {
        public MakeLineItemsViewModel(params string[] items)
        {
            Items = items;
        }

        public string[] Items { get; }
    }
}