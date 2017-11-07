using System.Data.Entity;
using StackCafe.MakeLineMonitor.Models;

namespace StackCafe.MakeLineMonitor.Ef
{
    public class MakeLineMonitorContext : DbContext
    {
        public MakeLineMonitorContext() : base("Server=localhost;Database=StackCafeMakeLineMonitor;Trusted_Connection=True;")
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}