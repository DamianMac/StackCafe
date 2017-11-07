using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Serilog;
using Serilog.Context;
using StackCafe.MakeLineMonitor.Models;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        private static Random _random = new Random();
        private ConcurrentDictionary<Guid, OrderDto> orders = new ConcurrentDictionary<Guid, OrderDto>();

        public void Add(Guid orderId, string coffeeType)
        {
            Log.Information("Adding order {OrderId} for coffee: {CoffeeType}...", orderId, coffeeType);
            if (!orders.TryAdd(orderId, new OrderDto() { CoffeeType = coffeeType, Colour = Color.FromArgb(_random.Next(256), _random.Next(256), _random.Next(256))
            }))
            {
                Log.Error("An order was added twice (ID: {OrderId})", orderId);
            }
        }

        public void Remove(Guid orderId)
        {
            Log.Information("Removing order {OrderId}...", orderId);
            OrderDto removedOrder;
            if (this.orders.TryRemove(orderId, out removedOrder))
            {
                Log.Information("Order was removed (ID: {OrderId}, Coffee: {RemovedOrder})", orderId, removedOrder.CoffeeType);
            }
            else
            {
                Log.Warning("The order was already removed (ID: {OrderId})", orderId);
            }
        }

        public IEnumerable<OrderDto> GetOrders()
        {
            return this.orders.Values;
        }
    }
}
