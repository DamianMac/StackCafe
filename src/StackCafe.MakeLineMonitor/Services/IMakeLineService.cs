using System;
using System.Collections.Generic;
using System.Drawing;

namespace StackCafe.MakeLineMonitor.Services
{
    public interface IMakeLineService
    {
        void Add(Guid orderId, string coffeeType);
        void Remove(Guid orderId);
        IEnumerable<OrderDto> GetOrders();
    }

    public class OrderDto
    {
        public string CoffeeType
        {
            get;
            set;
        }

        public Color Colour
        {
            get;
            set;
        }
    }
}