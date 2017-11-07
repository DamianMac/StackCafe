using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCafe.Cashier.Ef
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext() : base("Server=localhost;Database=StackCafeCustomers;Trusted_Connection=True;")
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }

    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<CustomerOrder> OrderHistory { get; set; }

    }

    public class CustomerOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public string Coffee { get; set; }

    }
}
