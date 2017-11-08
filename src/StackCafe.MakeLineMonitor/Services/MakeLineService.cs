using System;
using System.Collections.Generic;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        public Dictionary<Guid, string> MakeLineItems { get; set; }

        public MakeLineService()
        {
            MakeLineItems = new Dictionary<Guid, string>();
        }

        public void Add(Guid orderId, string coffeeType)
        {
            lock(MakeLineItems)
                this.MakeLineItems.Add(orderId, coffeeType);
        }

        public void Remove(Guid orderId)
        {
            lock (MakeLineItems)
                this.MakeLineItems.Remove(orderId);
        }

        public IEnumerable<string> GetItems()
        {
            lock (MakeLineItems)
            {
                return MakeLineItems.Values;
            }
        }
    }
}
