using System;

namespace StackCafe.MakeLineMonitor.Models
{
    public class Order
    {
        public Order(Guid orderId, string coffeeType)
        {
            this.Id = orderId;
            this.CoffeeType = coffeeType;
        }

        public Guid Id { get; }

        public string CoffeeType { get; }

        public bool IsPaid { get; set; }
    }
}