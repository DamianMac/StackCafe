using System;
using Autofac;
using StackCafe.Catalog.Handlers;
using StackCafe.Catalog.MessageContracts;
using StackCafe.Catalog.Messages;
using StackCafe.Catalog.Messaging;

namespace Activity3
{
    public class DispatchingMessageBus : IBus
    {
        readonly IBus _requestBus;
        readonly ILifetimeScope _lifetimeScope;

        public DispatchingMessageBus(IBus requestBus, ILifetimeScope lifetimeScope)
        {
            _requestBus = requestBus;
            _lifetimeScope = lifetimeScope;
        }

        public void Send<TBusCommand>(TBusCommand busCommand) where TBusCommand : IBusCommand
        {
            using (var handlerLifetime = _lifetimeScope.BeginLifetimeScope())
            {
                var handler = handlerLifetime.Resolve<IHandleCommand<TBusCommand>>();
                handler.Handle(busCommand);
            }
        }

        public TResponse Request<TRequest, TResponse>(IBusRequest<TRequest, TResponse> busRequest)
            where TRequest : IBusRequest<TRequest, TResponse> where TResponse : IBusResponse
        {
            return _requestBus.Request(busRequest);
        }
    }
}
