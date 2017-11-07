using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        private List<(Guid OrderId, string CoffeeType)> _pendingOrders = new List<(Guid, string)>();

        public void Add(Guid orderId, string coffeeType)
        {
            lock (_pendingOrders)
            {
                _pendingOrders.Add((orderId, coffeeType));
            }
        }

        public IEnumerable<(Guid OrderId, string CoffeeType)> GetMakeline()
        {
            lock (_pendingOrders)
            {
                return _pendingOrders.ToList();
            }
        }

        public void Remove(Guid orderId)
        {
            lock (_pendingOrders)
            {
                var pendingOrder = _pendingOrders.SingleOrDefault(p => p.OrderId == orderId);
                if (!pendingOrder.Equals(default(ValueTuple<Guid, string>)))
                {
                    _pendingOrders.Remove(pendingOrder);
                }
            }
        }
    }
}
