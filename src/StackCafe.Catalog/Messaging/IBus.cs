using StackCafe.Catalog.MessageContracts;

namespace StackCafe.Catalog.Messaging
{
    public interface IBus
    {
        void Send<TBusCommand>(TBusCommand busCommand) where TBusCommand : IBusCommand;

        TResponse Request<TRequest, TResponse>(IBusRequest<TRequest, TResponse> busRequest)
            where TRequest : IBusRequest<TRequest, TResponse>
            where TResponse : IBusResponse;
    }
}
