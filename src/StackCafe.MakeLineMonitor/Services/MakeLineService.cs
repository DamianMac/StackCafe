using System;
using System.Collections.Generic;
using System.Linq;
using StackCafe.MakeLineMonitor.Models;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        public MakeLineService()
        {
            this.LineOrders = new List<MakeLineItem>();
        }

        public void Add(Guid orderId, string coffeeType)
        {
            LineOrders.Add(new MakeLineItem(coffeeType, orderId));
        }

        public void Remove(Guid orderId)
        {
            var item = LineOrders.Find(o => o.OrderId == orderId);
            this.LineOrders.Remove(item);
        }

        public MakeLineItem[] GetOrders()
        {
            return this.LineOrders.ToArray();
        }

        private List<MakeLineItem> LineOrders { get; }
    }
}
