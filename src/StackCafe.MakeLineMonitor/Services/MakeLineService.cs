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

        public void Add(Guid orderId, string itemName, string itemType)
        {
            Items[orderId] = itemName;
        }

        public void Remove(Guid orderId)
        {
            Items.Remove(orderId);
        }

        public IEnumerable<string> Get()
        {
            return Items.Values;
        }
    }
}
