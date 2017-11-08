using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace StackCafe.Cashier.Services
{
    public class InMemoryOrderHistory : IOrderHistory
    {
        private readonly ConcurrentDictionary<string, List<string>> storage = new ConcurrentDictionary<string, List<string>>(); 
        public void AddOrder(string customerName, string[] orderItems)
        {
            storage.AddOrUpdate(customerName, orderItems.ToList(), (c, i) => i.Union(orderItems).ToList());
        }

        public string GetFavoriteItem(string customer)
        {
            List<string> items;
            if (storage.TryGetValue(customer, out items))
            {
                return items.GroupBy(x => x).OrderByDescending(g => g.Count()).FirstOrDefault()?.FirstOrDefault();
            }

            return null;
        }
    }
}