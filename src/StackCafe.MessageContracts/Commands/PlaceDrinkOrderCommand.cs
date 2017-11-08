using System;
using System.Collections.Generic;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Commands
{
    public class PlaceDrinkOrderCommand : IBusCommand
    {
        public PlaceDrinkOrderCommand()
        {
        }

        public PlaceDrinkOrderCommand(Guid orderId, List<Item> items)
        {
            OrderId = orderId;
            Items = items;
        }

        public Guid OrderId { get; set; }
        public List<Item> Items { get; set; }
    }
}
