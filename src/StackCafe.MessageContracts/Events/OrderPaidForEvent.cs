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
            Amount = amnount;
            OrderId = orderId;
        }

        public Guid OrderId { get; set; }
        public CurrencyAmount Amount { get; set; }
    }

    public class CurrencyAmount
    {
        public CurrencyAmount(Currency currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }

        public Currency Currency { get; set; }
        public decimal Amount { get; set; }
    }
}