using System;
using System.ComponentModel.DataAnnotations.Schema;
using Serilog;

namespace StackCafe.Waiter.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Guid Id { get; protected set; }

        public virtual bool Paid { get; protected set; }

        public virtual bool Made { get; protected set; }

        public virtual string Coffee { get; protected set; }

        public virtual string CustomerName { get; protected set; }

        public virtual bool IsDelivered { get; protected set; }

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