using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackCafe.Cashier.Services
{
    public interface IRecommendationService
    {
        Task<string[]> AskForRecommendations(string customer, List<string> items);
    }
}