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
            var makelineItems = items.Select(i => new MakeLineItem {Name = i.ItemName, Type = i.ItemType, PrepTime = TimeSpan.FromSeconds(i.ItemPrepTime), Code = i.ItemCode}).ToList();
            lock (ItemsLock)
            {
                Items.Add(orderId, makelineItems);
            }
        }

        public void Remove(Guid orderId, string itemCode)
        {
            if (!Items.ContainsKey(orderId))
            {
                return;
            }

            lock (ItemsLock)
            {
                var item = Items[orderId].First(i => i.Code == itemCode);
                Items[orderId].Remove(item);
            }
        }

        public List<List<MakeLineItem>> Get()
        {
            lock (ItemsLock)
            {
                return Items.Values.ToList();
            }
        }
    }
}
