using System.Linq;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Commands;
using StackMechanics.StackCafe.Infrastructure;

namespace StackMechanics.StackCafe.CommandHandlers
{
    public class CustomerPlaceOrderCommandHandler : IHandleCommand<CustomerPlaceOrderCommand>
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerPlaceOrderCommandHandler(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Handle(CustomerPlaceOrderCommand command)
        {
            var customer = _customerRepository.Get(command.CustomerId);
            var orderItems = command.Items
                .Select(item => new OrderItem(item.Name, item.Quantity))
                .ToArray();
            customer.PlaceOrder(command.OrderId, orderItems);
        }
    }
}