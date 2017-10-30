using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate;

namespace StackMechanics.StackCafe.Domain.Services
{
    public interface IWaiter : IDomainService
    {
        void DeliverOrderToCustomer(Order order, Customer customer);
    }
}