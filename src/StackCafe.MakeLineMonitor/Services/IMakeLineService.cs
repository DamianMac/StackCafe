using System;
using StackCafe.MessageContracts;

namespace StackCafe.MakeLineMonitor.Services
{
    public interface IMakeLineService
    {
        void Add(Guid orderId, OrderItemDto[] items);
        void Remove(Guid orderId);
        OrderItemDto[] GetAllItems();
    }

    
}