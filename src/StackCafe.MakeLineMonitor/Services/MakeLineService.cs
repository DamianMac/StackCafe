using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        private readonly ConcurrentDictionary<Guid, string[]> _makeLines;

        public MakeLineService()
        {
            _makeLines = new ConcurrentDictionary<Guid, string[]>();
        }

        public void Add(Guid orderId, string[] items)
        {
            _makeLines.TryAdd(orderId, items);
        }

        public void Remove(Guid orderId)
        {
            var empty = new string[]{};
            _makeLines.TryRemove(orderId, out empty);
        }

        public string[] GetAllItems()
        {
            return _makeLines.Values.SelectMany(l => l).ToArray();

        }
    }
}
