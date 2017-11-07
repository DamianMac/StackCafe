using StackCafe.MakeLineMonitor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        private List<OrderItem> _pendingOrders = new List<OrderItem>();

        public void Add(Guid orderId, string coffeeType)
        {
            lock (_pendingOrders)
            {
                _pendingOrders.Add(new OrderItem() { OrderId = orderId, Type = coffeeType });
            }
        }

        public IEnumerable<OrderItem> GetMakeline()
        {
            lock (_pendingOrders)
            {
                var reversed = _pendingOrders
                    .ToList();

                reversed.Reverse();
                return reversed;
            }
        }

        public void Remove(Guid orderId)
        {
            lock (_pendingOrders)
            {
                var pendingOrder = _pendingOrders.SingleOrDefault(p => p.OrderId == orderId);
                if (pendingOrder != null)
                {
                    pendingOrder.CompletedTime = DateTime.Now;
                }
            }
            CleanPendingList();
        }

        private void CleanPendingList()
        {
            lock (_pendingOrders)
            {
                var oldOrders = _pendingOrders.Where(p => p.CompletedTime.HasValue && p.CompletedTime < DateTime.Now.AddMinutes(-1)).ToList();
                foreach (var item in oldOrders)
                {
                    _pendingOrders.Remove(item);
                }
            }
        }
    }
}
