using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nimbus;
using Serilog;
using StackCafe.MakeLineMonitor.Models;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        private readonly IDictionary<Guid, Order> line = new Dictionary<Guid, Order>();

        public void Add(Guid orderId, string customerName, string coffeeType)
        {
            Log.Information("Add Order {OrderId} Coffer {CoffeeType}", orderId, coffeeType);
           this.line.Add(orderId, new Order(orderId, customerName, coffeeType));
        }

        public void SetPaid(Guid orderId)
        {
            Order order;
            if (line.TryGetValue(orderId, out order))
            {
                Log.Information("Paid order {OrderId}", orderId);
                order.IsPaid = true;
            }
        }

        public void Remove(Guid orderId)
        {
            if (line.ContainsKey(orderId))
            {
                Log.Information("Remove order {OrderId}", orderId);
                line.Remove(orderId);
            }
        }

        public Order[] CurrentOrders => this.line.Values.ToArray();
    }
}
