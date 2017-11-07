using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackCafe.Waiter.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public bool Paid { get; set; }

        public bool Made { get; set; }
    }
}