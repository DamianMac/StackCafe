using System;

namespace StackCafe.MakeLineMonitor.Services
{
    public interface IMakeLineService
    {
        void Add(Guid orderId, string[] items);
        void Remove(Guid orderId);
        string[] GetAllItems();
    }
}