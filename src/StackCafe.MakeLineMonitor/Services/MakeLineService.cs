using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using StackCafe.MessageContracts;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        private readonly ConcurrentDictionary<Guid, OrderItemDto[]> _makeLines;

        public MakeLineService()
        {
            _makeLines = new ConcurrentDictionary<Guid, OrderItemDto[]>();
        }

        public void Add(Guid orderId, OrderItemDto[] items)
        {
            _makeLines.TryAdd(orderId, items);
        }

        public void Remove(Guid orderId)
        {
            var empty = new OrderItemDto[]{};
            _makeLines.TryRemove(orderId, out empty);
        }

        public OrderItemDto[] GetAllItems()
        {
            return _makeLines.Values.SelectMany(l => l).ToArray();

        }
    }
}
