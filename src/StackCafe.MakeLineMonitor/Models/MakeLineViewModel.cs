using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackCafe.MakeLineMonitor.Models
{
    public class MakeLineViewModel
    {
        public MakeLineViewModel(IEnumerable<OrderViewModel> orders)
        {
            Orders = orders.ToArray();
        }

        public OrderViewModel[] Orders { get; }
    }
}