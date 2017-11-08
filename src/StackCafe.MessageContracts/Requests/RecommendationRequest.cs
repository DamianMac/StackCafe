using System;
using Nimbus.MessageContracts;
using StackCafe.MessageContracts.Response;

namespace StackCafe.MessageContracts.Requests
{
    public class RecommendationRequest : IBusRequest<RecommendationRequest, RecommendationResponse>
    {
        public string Customer { get; set; }
        public string[] RecommendedItems { get; set; }
    }
}