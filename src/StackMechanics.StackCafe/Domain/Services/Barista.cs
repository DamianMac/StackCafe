using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate;

namespace StackMechanics.StackCafe.Domain.Services
{
    class Barista : IBarista
    {
        public void MakeOrder(Order order)
        {
            //TODO: Mumble, mumble... Don't ask about this coffee. You've never heard of it.
            order.MarkAsReady();
        }
    }
}