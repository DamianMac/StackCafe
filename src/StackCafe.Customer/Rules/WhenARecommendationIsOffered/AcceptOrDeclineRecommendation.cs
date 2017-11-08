using System;
using System.Threading.Tasks;
using Nimbus.Handlers;
using Serilog;
using StackCafe.MessageContracts.Requests;
using StackCafe.MessageContracts.Response;

namespace StackCafe.Customer.Rules.WhenARecommendationIsOffered
{
    public class AcceptOrDeclineRecommendation : IHandleRequest<RecommendationRequest, RecommendationResponse>
    {
        private static readonly Random random = new Random();
        public Task<RecommendationResponse> Handle(RecommendationRequest request)
        {
            var accepted = random.Next(0, 10) < 5;
            if (accepted)
            {
                Log.Information("Accepted recommendation {@Items}", request.RecommendedItems);
            }
            else
            {
                Log.Information("Declined recommendation {@Items}", request.RecommendedItems);
            }

            return Task.FromResult(new RecommendationResponse() {IsAccepted = accepted});
        }
    }
}