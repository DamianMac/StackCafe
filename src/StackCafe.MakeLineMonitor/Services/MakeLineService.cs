using System;
using System.Collections.Generic;
using System.Linq;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        public Dictionary<Guid, string> Items { get; }

        public MakeLineService()
        {
            Items = new Dictionary<Guid, string>();
        }

        public void Add(Guid orderId, string coffeeType)
        {
            Items[orderId] = coffeeType;
        }

        public void Remove(Guid orderId)
        {
            Items.Remove(orderId);
        }

        public string[] Get()
        {
            return Items.Values.ToArray();
        }
    }
}
