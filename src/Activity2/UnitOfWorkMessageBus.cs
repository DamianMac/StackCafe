﻿using System;
using StackCafe.Catalog.Handlers;
using StackCafe.Catalog.MessageContracts;
using StackCafe.Catalog.Messages;
using StackCafe.Catalog.Messaging;

namespace Activity2
{
    public class UnitOfWorkMessageBus : IBus
    {
        readonly IBus _requestBus;
        readonly AddProductCommandHandler _addProductHandler;

        public UnitOfWorkMessageBus(IBus requestBus, AddProductCommandHandler addProductHandler)
        {
            _requestBus = requestBus;
            _addProductHandler = addProductHandler;
        }

        public void Send<TBusCommand>(TBusCommand busCommand) where TBusCommand : IBusCommand
        {
            if (busCommand is AddProductCommand apc)
            {
                _addProductHandler.Handle(apc);
            }
            else
            {
                throw new NotSupportedException($"No handler is registered for command type {busCommand.GetType()}.");
            }
        }

        public TResponse Request<TRequest, TResponse>(IBusRequest<TRequest, TResponse> busRequest)
            where TRequest : IBusRequest<TRequest, TResponse> where TResponse : IBusResponse
        {
            return _requestBus.Request(busRequest);
        }
    }
}
