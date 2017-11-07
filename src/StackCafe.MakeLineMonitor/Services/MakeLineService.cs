using System;
using System.Collections.Generic;
using System.Linq;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        private readonly Dictionary<Guid, string> _ordersOnMakeLine;

        public MakeLineService()
        {
            _ordersOnMakeLine = new Dictionary<Guid, string>();
        }

        public void Add(Guid orderId, string coffeeType)
        {
            _ordersOnMakeLine.Add(orderId, coffeeType);
        }

        public void Remove(Guid orderId)
        {
            _ordersOnMakeLine.Remove(orderId);
        }

        public string[] GetCoffeesOnMakeLine()
        {
            return _ordersOnMakeLine.Select(s => s.Value).ToArray();
        }
    }
}
