using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nimbus;
using Serilog;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        private readonly IDictionary<Guid, string> line = new Dictionary<Guid, string>();

        public void Add(Guid orderId, string coffeeType)
        {
            Log.Information("Add Order {OrderId} Coffer {CoffeeType}", orderId, coffeeType);
           this.line.Add(orderId, coffeeType);
        }

        public void Remove(Guid orderId)
        {
            if (line.ContainsKey(orderId))
            {
                Log.Information("Remove order {OrderId}", orderId);
                line.Remove(orderId);
            }
        }

        public string[] CurrentOrders => this.line.Values.ToArray();
    }
}
