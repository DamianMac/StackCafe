using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate;
using StackMechanics.StackCafe.Domain.Aggregates.CustomerAggregate.Commands;
using StackMechanics.StackCafe.Infrastructure;

namespace StackMechanics.StackCafe.CommandHandlers
{
    public class SignUpCustomerCommandHandler : IHandleCommand<SignUpCustomerCommand>
    {
        private readonly IRepository<Customer> _repository;

        public SignUpCustomerCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public void Handle(SignUpCustomerCommand command)
        {
            var customer = Customer.SignUp(command.Id, command.Name);
            _repository.Add(customer);
        }
    }
}