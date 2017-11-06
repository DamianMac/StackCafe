using System;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Events;
using StackMechanics.StackCafe.Domain.Services;
using StackMechanics.StackCafe.Infrastructure;

namespace StackMechanics.StackCafe.Domain.Rules.WhenAnOrderIsPaidFor
{
    public class MakeCoffeeForTheCustomer : IHandleEvent<OrderPaidForEvent>
    {
        private readonly IBarista _barista;

        public MakeCoffeeForTheCustomer(IBarista barista)
        {
            _barista = barista;
        }

        public void Handle(OrderPaidForEvent e)
        {

        }
    }
}
