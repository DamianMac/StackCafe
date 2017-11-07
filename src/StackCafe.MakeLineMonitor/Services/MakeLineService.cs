using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serilog;
using Serilog.Context;
using StackCafe.MakeLineMonitor.Models;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        private ConcurrentDictionary<Guid, string> orders = new ConcurrentDictionary<Guid, string>();

        public void Add(Guid orderId, string coffeeType)
        {
            Log.Information("Adding order {OrderId} for coffee: {CoffeeType}...", orderId, coffeeType);
            if (!orders.TryAdd(orderId, coffeeType))
            {
                Log.Error("An order was added twice (ID: {OrderId})", orderId);
            }
        }

        public void Remove(Guid orderId)
        {
            Log.Information("Removing order {OrderId}...", orderId);
            string removedOrder;
            if (this.orders.TryRemove(orderId, out removedOrder))
            {
                Log.Information("Order was removed (ID: {OrderId}, Coffee: {RemovedOrder})", orderId, removedOrder);
            }
            else
            {
                Log.Warning("The order was already removed (ID: {OrderId})", orderId);
            }
        }

        public string[] GetOrders()
        {
            return this.orders.Values.ToArray();
        }
    }
}
