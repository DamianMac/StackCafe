using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace StackCafe.Cashier.Services
{
    class RecommendationService : IRecommendationService
    {
        private static Random random = new Random();
        public Task<string[]> AskForRecommendations(string customer, List<string> items)
        {
            var recommendedItems = new[] {"Muffin (Chocolate)", "Bliss Ball", "Toastie", "Big Biscuit"}.ToList();
            var currentRecommendedItems = recommendedItems.OrderBy(item => item, new RandomComparer()).Take(random.Next(0, recommendedItems.Count - 1)).ToArray();

            Log.Information("Recommending {@Items} to {Customer}", currentRecommendedItems, customer);

            return Task.FromResult(currentRecommendedItems.ToArray());
        }
    }
}