using System;

namespace StackCafe.MakeLineMonitor.Models
{
    public class MakeLineItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public TimeSpan PrepTime { get; set; }
    }
}
