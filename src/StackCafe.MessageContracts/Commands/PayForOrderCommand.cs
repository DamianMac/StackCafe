﻿using Nimbus.MessageContracts;
using System;

namespace StackCafe.MessageContracts.Commands
{
    public class PayForOrderCommand : IBusCommand
    {
        public PayForOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; set; }
    }
}