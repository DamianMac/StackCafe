using Autofac;
using StackMechanics.StackCafe.Domain.Infrastructure;

namespace StackMechanics.StackCafe.Infrastructure
{
    public class Mediator : IMediator
    {
        private readonly ILifetimeScope _scope;

        public Mediator(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _scope.Resolve<IHandleCommand<TCommand>>();
            handler.Handle(command);
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var handlers = _scope.Resolve<IHandleEvent<TEvent>[]>();
            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}