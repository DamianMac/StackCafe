using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackCafe.Cashier.Services
{
    class RecommendationService : IRecommendationService
    {
        private readonly Random random = new Random();
        public Task<string[]> AskForRecommendations(string customer, List<string> items)
        {
            var recommendedItems = new[] {"Muffin (Chocolate)", "Bliss Ball", "Toastie", "Big Biscuit"}.ToList();
            var currentRecommendedItems = recommendedItems.OrderBy(item => item, new RandomComparer()).Take(random.Next(0, recommendedItems.Count - 1));
            return Task.FromResult(currentRecommendedItems.ToArray());
        }
    }
}