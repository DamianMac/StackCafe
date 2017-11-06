using System;
using StackCafe.Catalog.Handlers;
using StackCafe.Catalog.MessageContracts;
using StackCafe.Catalog.Messages;
using StackCafe.Catalog.Messaging;
using Autofac;

namespace Activity2
{
    public class Activity2MessageBus : IBus
    {
        readonly IBus _requestBus;
        readonly AddProductCommandHandler _addProductHandler;
        readonly ILifetimeScope _lifetimeScope;

        public Activity2MessageBus(IBus requestBus, ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _requestBus = requestBus;
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
