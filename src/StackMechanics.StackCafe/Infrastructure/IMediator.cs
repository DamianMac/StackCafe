using StackMechanics.StackCafe.Domain.Infrastructure;
using StackMechanics.StackCafe.Domain.Rules.WhenAnOrderIsPaidFor;

namespace StackMechanics.StackCafe.Infrastructure
{
    public interface IMediator
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}