using Autofac;
using StackCafe.Catalog.MessageContracts;
using StackCafe.Catalog.Messaging;

namespace Activity2
{
    public class Activity2MessageBus : IBus
    {
        readonly IBus _requestBus;
        private readonly ILifetimeScope _lifeTimeScope;

        public Activity2MessageBus(IBus requestBus, ILifetimeScope lifeTimeScope)
        {
            _requestBus = requestBus;
            _lifeTimeScope = lifeTimeScope;
        }

        public void Send<TBusCommand>(TBusCommand busCommand) where TBusCommand : IBusCommand
        {
            using (var handlerLifetime = _lifeTimeScope.BeginLifetimeScope())
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
