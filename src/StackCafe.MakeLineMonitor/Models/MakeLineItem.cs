using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackCafe.MakeLineMonitor.Models
{
    public class MakeLineItem
    {
        public MakeLineItem(string orderType, Guid orderId)
        {
            this.OrderId = orderId;
            this.OrderType = orderType;

            Random rnd = new Random();
            this.Price = rnd.NextDouble() * 3;
            this.Price = Math.Round(this.Price, 2);
        }
        public string OrderType { get; set; }

        public Guid OrderId { get; set; }

        public double Price { get; set; }
    }
}