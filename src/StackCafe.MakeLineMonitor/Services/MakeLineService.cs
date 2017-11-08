using System;
using System.Collections.Generic;
using System.Linq;
using StackCafe.MakeLineMonitor.Models;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        public Dictionary<Guid, MakeLineItem> Items { get; }

        public MakeLineService()
        {
            Items = new Dictionary<Guid, MakeLineItem>();
        }

        public void Add(Guid orderId, string itemName, string itemType)
        {
            Items[orderId] = new MakeLineItem
            {
                ItemName = itemName,
                ItemType = itemType
            };
        }

        public void Remove(Guid orderId)
        {
            Items.Remove(orderId);
        }

        public IEnumerable<MakeLineItem> Get()
        {
            return Items.Values;
        }
    }
}
