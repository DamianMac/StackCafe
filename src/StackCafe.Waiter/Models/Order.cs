using System;
using System.ComponentModel.DataAnnotations.Schema;
using Serilog;

namespace StackCafe.Waiter.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get;  set; }

        public bool Paid { get;  set; }

        public bool Made { get;  set; }

        public string Coffee { get;  set; }

        public string CustomerName { get;  set; }

        public bool IsDelivered { get; private set; }

        public bool CanBeDelivered()
        {
            if (!Made)
            {
                Log.Information("{OrderId} isn't ready yet. We can't give it to the customer.", Id);
                return false;
            }

            if (!Paid)
            {
                Log.Information("{OrderId} hasn't been paid for yet. We can't give it to the customer.", Id);
                return false;
            }
            if (IsDelivered)
            {
                Log.Information("{OrderId} has already been delivered", Id);
                return false;
            }

            Log.Information("{OrderId} should be delivered.", Id);
            return true;
        }

        public void MarkAsDelivered()
        {
            if (!CanBeDelivered()) throw new Exception();

            IsDelivered = true;

            Log.Information("Delivering {OrderId} to the customer.", Id);

            // This DOES is in process NOT Bus
            // DomainEvents.Raise(new OrderDeliveredEvent(this));
        }
    }
}