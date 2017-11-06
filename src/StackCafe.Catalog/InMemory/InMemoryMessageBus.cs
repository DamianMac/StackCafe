using System;
using StackCafe.Catalog.Handlers;
using StackCafe.Catalog.MessageContracts;
using StackCafe.Catalog.Messages;
using StackCafe.Catalog.Messaging;

namespace StackCafe.Catalog.InMemory
{
    public class InMemoryMessageBus : IBus
    {
        readonly AddProductCommandHandler _addProductHandler;
        readonly LookupProductRequestHandler _lookupProductHandler;

        public InMemoryMessageBus(
            AddProductCommandHandler addProductHandler,
            LookupProductRequestHandler lookupProductHandler)
        {
            _addProductHandler = addProductHandler;
            _lookupProductHandler = lookupProductHandler;
        }

        public void Send<TBusCommand>(TBusCommand busCommand) where TBusCommand : IBusCommand
        {
            if (busCommand is AddProductCommand)
            {
                var apc = busCommand as AddProductCommand;
                _addProductHandler.Handle(apc);
            }
            else
            {
                throw new NotSupportedException($"No handler is registered for command type {busCommand.GetType()}.");
            }
        }

        public TResponse Request<TRequest, TResponse>(IBusRequest<TRequest, TResponse> busRequest) where TRequest : IBusRequest<TRequest, TResponse> where TResponse : IBusResponse
        {
            if (busRequest is LookupProductRequest lpc)
            {
                return (TResponse)(object)_lookupProductHandler.Handle(lpc);
            }

            throw new NotSupportedException($"No handler is registered for request type {busRequest.GetType()}.");
        }
    }
}
