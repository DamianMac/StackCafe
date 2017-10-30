using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Infrastructure
{
    public interface IMediator
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}