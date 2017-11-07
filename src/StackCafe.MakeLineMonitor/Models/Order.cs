using System;

namespace StackCafe.MakeLineMonitor.Models
{
    public class Order
    {
        public Order(Guid orderId, string customerName, string coffeeType)
        {
            this.Id = orderId;
            this.CustomerName = customerName;
            this.CoffeeType = coffeeType;
        }

        public Guid Id { get; }
        public string CustomerName { get; }

        public string CoffeeType { get; }

        public bool IsPaid { get; set; }
    }
}