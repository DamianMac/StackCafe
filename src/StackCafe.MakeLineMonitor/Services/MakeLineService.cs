using System;
using System.Collections.Generic;
using System.Linq;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        private readonly Dictionary<Guid, string> _items = new Dictionary<Guid,string>();

        public void Add(Guid orderId, string coffeeType)
        {
            _items.Add(orderId, coffeeType);
        }

        public void Remove(Guid orderId)
        {
            _items.Remove(orderId);
        }

        public string[] Get()
        {
            return _items.Values.ToArray();
        }
    }
}
