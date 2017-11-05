using System;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Commands;
using StackMechanics.StackCafe.Infrastructure;

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
            throw new NotImplementedException();
        }
    }
}