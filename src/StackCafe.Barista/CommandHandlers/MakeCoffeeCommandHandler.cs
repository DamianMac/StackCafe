using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nimbus;
using Nimbus.Handlers;
using StackCafe.MessageContracts.Commands;
using StackCafe.MessageContracts.Events;

namespace StackCafe.Barista.CommandHandlers
{
    public class MakeCoffeeCommandHandler : IHandleCommand<MakeCoffeeCommand>
    {
        private readonly IBus _bus;
        private readonly Serilog.ILogger _logger;

        public MakeCoffeeCommandHandler(IBus bus, Serilog.ILogger logger)
        {
            _bus = bus;
            _logger = logger;
        }
        
        public async Task Handle(MakeCoffeeCommand busCommand)
        {
            _logger.Debug("{OrderStatus} {Coffee} for {Customer}", "Making", busCommand.CoffeeType, busCommand.CustomerName);
            await Task.Delay(TimeSpan.FromSeconds(1));
            _logger.Information("{OrderStatus} {Coffee} for {Customer}", "Made", busCommand.CoffeeType, busCommand.CustomerName);

            await _bus.Publish(new OrderIsReadyEvent(busCommand.OrderId, busCommand.CoffeeType, busCommand.CustomerName));
        }
    }
}
