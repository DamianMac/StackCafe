using System;

namespace StackCafe.Notifications.Domain
{
    public class TrackedOrder
    {
        public Guid OrderId { get; set; }
        public string Customer { get; set; }
        public string Coffee { get; set; }
        public string PhoneNumber { get; set; }

    }
}