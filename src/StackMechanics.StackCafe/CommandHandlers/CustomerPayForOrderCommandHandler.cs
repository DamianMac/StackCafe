using System;
using System.Linq;
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
            var customer = _customerRepository.Get(command.CustomerId);
            //customer.PayFor(customer.Orders.Get(command.OrderId));
            var order = customer.Orders.First(o => o.Id == command.OrderId);
            customer.AcceptDeliveryOfOrder(order);
            //customer.IsCaffeinated = true;
        }
    }
}