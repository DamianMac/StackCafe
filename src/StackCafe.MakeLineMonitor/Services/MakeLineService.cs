using System;
using System.Collections.Generic;
using System.Linq;
using StackCafe.MakeLineMonitor.Models;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        public Dictionary<Guid, string> _items;

        public MakeLineService()
        {
            _items = new Dictionary<Guid, string>();
        }

        public void Add(Guid orderId, string coffeeType)
        {
            _items.Add(orderId, coffeeType);
        }

        public void Remove(Guid orderId)
        {
            _items.Remove(orderId);
        }

        public string[] GetLineItems()
        {
            return _items.Values.ToArray();
        }
    }
}
