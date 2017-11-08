using System;
using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Events
{
    public class OrderPaidForEvent : IBusEvent
    {
        private OrderPaidForEvent()
        {
        }

        public OrderPaidForEvent(Guid orderId, CurrencyAmount amnount)
        {
            Amnount = amnount;
            OrderId = orderId;
        }

        public Guid OrderId { get; set; }
        public CurrencyAmount Amnount { get; set; }
    }

    public class CurrencyAmount
    {
        public CurrencyAmount(Currency currency, decimal amount)
        {
            Amount = amount;
            Currency = currency;
        }

        public Currency Currency { get; set; }
        public decimal Amount { get; set; }
    }
}