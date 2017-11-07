using System;
using System.Drawing;

namespace StackCafe.MakeLineMonitor.Models
{
    public class MakeLineViewModel
    {
        public MakeLineViewModel(params OrderItem[] items)
        {
            Items = items;
        }

        public OrderItem[] Items { get; }
    }

    public class OrderItem
    {
        public Guid OrderId { get; set; }
        public string Type { get; set; }
        public DateTime? CompletedTime { get; set; }
        public string Colour
        {
            get
            {
                return CompletedTime.HasValue ? ColorTranslator.ToHtml(Color.Green) : ColorTranslator.ToHtml(Color.Red);

            }
        }

    }
}