namespace StackCafe.MakeLineMonitor.Models
{
    public class MakeLineViewModel
    {
        public MakeLineViewModel(params string[] items)
        {
            Items = items;
        }

        public string[] Items { get; }

        public decimal TotalAudSales { get; set; }

        public decimal TotalBtcSales { get; set; }
    }
}