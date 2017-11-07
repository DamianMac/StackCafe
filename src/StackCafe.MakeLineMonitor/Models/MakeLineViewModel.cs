using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackCafe.MakeLineMonitor.Models
{
    public class MakeLineViewModel
    {
        public MakeLineViewModel(params string[] items)
        {
            Items = items;
        }

        public string[] Items { get; }
    }
}