using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace StackCafe.MakeLineMonitor.Models
{
    public class OrderViewModel
    {
        public Guid OrderId { get; set; }

        public string CoffeeType { get; set; }

        public Color Colour { get; set; }
    }
}