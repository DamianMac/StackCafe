using System;
using System.Collections.Generic;
using System.Linq;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MessageContracts;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        public Dictionary<Guid, List<MakeLineItem>> Items { get; private set; }
        private object ItemsLock = new object();

        public MakeLineService()
        {
            Items = new Dictionary<Guid, List<MakeLineItem>>();
        }

        public void Add(Guid orderId, List<Item> items)
        {
            var makelineItems = items.Select(i => new MakeLineItem {ItemName = i.ItemName, ItemType = i.ItemType}).ToList();
            lock (ItemsLock)
            {
                Items.Add(orderId, makelineItems);

            }
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
