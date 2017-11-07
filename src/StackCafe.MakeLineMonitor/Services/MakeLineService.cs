using System;
using System.Collections.Generic;
using System.Linq;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        public MakeLineService()
        {
            this.LineOrders = new Dictionary<Guid, string>();
        }

        public void Add(Guid orderId, string coffeeType)
        {
            LineOrders.Add(orderId, coffeeType);
        }

        public void Remove(Guid orderId)
        {
            LineOrders.Remove(orderId);
        }

        public string[] GetOrders()
        {
            return this.LineOrders.Select(x => x.Value).ToArray();
        }

        private Dictionary<Guid,string> LineOrders { get; }
    }
}
