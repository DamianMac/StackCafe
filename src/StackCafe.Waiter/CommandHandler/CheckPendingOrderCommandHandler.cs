﻿using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Commands;
using StackCafe.MessageContracts.Events;
using StackCafe.Waiter.Services;
using ILogger = Serilog.ILogger;

namespace StackCafe.Waiter.CommandHandler
{
    public class CheckPendingOrderCommandHandler : IHandleCommand<CheckPendingOrderCommand>
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;
        private readonly IOrderDeliveryService _orderDeliveryService;

        public CheckPendingOrderCommandHandler(IBus bus, ILogger logger, IOrderDeliveryService orderDeliveryService)
        {
            _bus = bus;
            _logger = logger;
            _orderDeliveryService = orderDeliveryService;
        }

        public async Task Handle(CheckPendingOrderCommand busCommand)
        {
            var order = _orderDeliveryService.GetOrderFromId(busCommand.OrderId);
            if (order.Paid && !order.Made)
            {
                var command = new MakeCoffeeCommand {OrderId = order.Id, CustomerName = order.CustomerName,CoffeeType = order.Coffee};

                await _bus.Send(command);
            }

        }
    }

}