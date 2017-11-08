using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCafe.MessageContracts
{
    public class OrderItemDto
    {
        public string Name { get; set; }
        public bool WasRecommended { get; set; }
    }
}
