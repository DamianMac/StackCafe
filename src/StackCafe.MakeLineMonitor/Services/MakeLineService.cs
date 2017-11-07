using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Antlr.Runtime;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        private  Dictionary<Guid, string> _ml  = new Dictionary<Guid, string>();
    


        public void Add(Guid orderId, string coffeeType)
        {
            _ml.Add(orderId, coffeeType);
         
        }

        public void Remove(Guid orderId)
        {
            _ml.Remove(orderId);
        }

        public string[] Items => _ml.Values.ToArray();
    }
}
