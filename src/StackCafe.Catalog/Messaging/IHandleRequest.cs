using StackCafe.Catalog.MessageContracts;

// ReSharper disable TypeParameterCanBeVariant

namespace StackCafe.Catalog.Messaging
{
    public interface IHandleRequest<TBusRequest, TBusResponse>
        where TBusRequest : IBusRequest<TBusRequest, TBusResponse>
        where TBusResponse : IBusResponse
    {
        TBusResponse Handle(TBusRequest request);
    }
}
