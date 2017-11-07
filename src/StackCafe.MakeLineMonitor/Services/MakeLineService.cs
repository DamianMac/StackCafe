using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        private Dictionary<Guid, string> _orders;
        private object sync = new object();
        public MakeLineService()
        {
            _orders = new Dictionary<Guid, string>();
        }

        public void Add(Guid orderId, string coffeeType)
        {
            lock (sync)
            {
                _orders.Add(orderId, coffeeType);
            }
        }

        public void Remove(Guid orderId)
        {
            lock (sync)
            {
                _orders.Remove(orderId);
            }
            
        }

        public string[] ListOrders()
        {
            lock (sync)
            {
                return _orders.Values.ToArray();
            }            
        }
    }
}
