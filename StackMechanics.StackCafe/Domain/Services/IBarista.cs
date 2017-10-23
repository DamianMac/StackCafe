using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate;

namespace StackMechanics.StackCafe.Domain.Services
{
    public interface IBarista: IDomainService
    {
        void MakeOrder(Order order);
    }
}