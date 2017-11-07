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
        public OrderItem(Guid orderId, string coffeeType)
        {
            OrderId = orderId;
            Type = coffeeType;
            OrderTime = DateTime.Now;
        }
        public Guid OrderId { get;  }
        public string Type { get;  }
        public DateTime OrderTime { get; }
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