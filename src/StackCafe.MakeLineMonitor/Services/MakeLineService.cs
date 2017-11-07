using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        ConcurrentDictionary<Guid,string> ml = new ConcurrentDictionary<Guid, string>();
        public void Add(Guid orderId, string coffeeType)
        {
            ml.TryAdd(orderId, coffeeType);
        }

        public void Remove(Guid orderId)
        {
            string val;
            ml.TryRemove(orderId,out val);
        }

        public string[] Items => ml.Values.ToArray();
    }
}
