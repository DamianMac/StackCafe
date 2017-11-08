using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackCafe.Cashier.Services
{
    internal interface IRecommendationService
    {
        Task<string[]> AskForRecommendations(string customer, List<string> items);
    }
}