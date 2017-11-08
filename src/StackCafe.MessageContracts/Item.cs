using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCafe.MessageContracts
{
    public class Item
    {
        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public int ItemPrepTime { get; set; }

        public string ItemType { get; set; }
    }

    public enum ItemType
    {
        Drink,
        Food
    }
}
