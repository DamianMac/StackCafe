using System;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Commands;
using StackMechanics.StackCafe.Infrastructure;
using System.Linq;
using StackMechanics.StackCafe.Domain.Infrastructure;
using StackMechanics.StackCafe.Domain.Rules.WhenAnOrderIsPaidFor;

namespace StackMechanics.StackCafe.CommandHandlers
{
    public class CustomerPayForOrderCommandHandler : IHandleCommand<CustomerPayForOrderCommand>
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerPayForOrderCommandHandler(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Handle(CustomerPayForOrderCommand command)
        {
            var customer = _customerRepository.Get(command.CustomerId);
            var order =  customer.Orders.Single(o => o.Id == command.OrderId);

            order.MarkAsPaidBy(customer);
        }
    }
}