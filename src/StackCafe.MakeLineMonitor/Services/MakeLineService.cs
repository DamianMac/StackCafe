using System;
using System.Collections.Generic;
using System.Linq;
using StackCafe.MakeLineMonitor.Ef;

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
            if (this.ordersDictionary.ContainsKey(orderId))
            {
                Serilog.Log.Information("Updating Order {orderId} from {previous} to {new}",
                    orderId,
                    this.ordersDictionary[orderId],
                    coffeeType);

                this.ordersDictionary[orderId] = coffeeType;
            }
            else
            {
                Serilog.Log.Information("Adding Order {orderId} for {new}", orderId, coffeeType);
                this.ordersDictionary.Add(orderId, coffeeType);
            }
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
