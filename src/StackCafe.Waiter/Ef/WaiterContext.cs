using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackCafe.Waiter.Models;

namespace StackCafe.Waiter.Ef
{
    public class WaiterContext : DbContext
    {
        public WaiterContext() : base("Server=localhost;Database=StackCafeWaiter;Trusted_Connection=True;")
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
