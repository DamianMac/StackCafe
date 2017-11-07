using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackCafe.MakeLineMonitor.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public string CoffeeType { get; set; }
    }
}