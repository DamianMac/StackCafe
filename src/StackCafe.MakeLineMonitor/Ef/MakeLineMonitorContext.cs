using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using StackCafe.MakeLineMonitor.Models;

namespace StackCafe.MakeLineMonitor.Ef
{
    public class MakeLineMonitorContext : DbContext
    {
        public MakeLineMonitorContext() : base("Server=localhost;Database=StackCafe;Trusted_Connection=True;")
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}