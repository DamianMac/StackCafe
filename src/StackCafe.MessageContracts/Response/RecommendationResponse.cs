using Nimbus.MessageContracts;

namespace StackCafe.MessageContracts.Response
{
    public class RecommendationResponse : IBusResponse
    {
        public bool IsAccepted { get; set; }
    }
}