namespace StackCafe.MakeLineMonitor.Models
{
    public class MakeLineViewModel
    {
        public MakeLineViewModel(params MakeLineItem[] items)
        {
            Items = items;
        }

        public MakeLineItem[] Items { get; }
    }
}