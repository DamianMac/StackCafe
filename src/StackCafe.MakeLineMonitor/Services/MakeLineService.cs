using System;
using System.Collections.Generic;
using System.Linq;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        private Dictionary<Guid, string> ordersDictionary;

        public MakeLineService()
        {
            this.ordersDictionary = new Dictionary<Guid, string>();
        }

        public void Add(Guid orderId, string coffeeType)
        {
            this.ordersDictionary.Add(orderId, coffeeType);
        }

        public void Remove(Guid orderId)
        {
            this.ordersDictionary.Remove(orderId);
        }
        
        public string[] GetAll()
        {
            return this.ordersDictionary.Values.ToArray();
        }

        public bool IsEmpty()
        {
            return this.ordersDictionary.Values.Count == 0;
        }
    }
}
