using System;
using System.Collections.Generic;
using System.Linq;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MessageContracts.Events;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        public Dictionary<Guid, List<MakeLineItem>> Items { get; }

        public MakeLineService()
        {
            Items = new Dictionary<Guid, List<MakeLineItem>>();
        }

        public void Add(Guid orderId, List<Item> items)
        {
            Items[orderId] = new List<MakeLineItem>(items.Select(i => new MakeLineItem
            {
                ItemName = i.ItemName,
                ItemType = i.ItemType
            }).ToList());
        }

        public void Remove(Guid orderId)
        {
            Items.Remove(orderId);
        }

        public List<List<MakeLineItem>> Get()
        {
            return Items.Values.ToList();
        }
    }
}
