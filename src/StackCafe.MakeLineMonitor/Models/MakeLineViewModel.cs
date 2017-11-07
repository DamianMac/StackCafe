namespace StackCafe.MakeLineMonitor.Models
{
    public class MakeLineViewModel
    {
        public MakeLineViewModel(params string[] items)
        {
            Items = items;
        }

        public string[] Items { get; }
    }
}