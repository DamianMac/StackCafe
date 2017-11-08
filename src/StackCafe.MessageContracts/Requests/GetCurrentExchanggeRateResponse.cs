using Nimbus.MessageContracts;
using StackCafe.MessageContracts.Events;

namespace StackCafe.MessageContracts.Requests
{
    public class GetCurrentExchanggeRateResponse : IBusResponse
    {
        public GetCurrentExchanggeRateResponse(CurrencyExchangeRate currentExchangeRate)
        {
            CurrentExchangeRate = currentExchangeRate;
        }

        public CurrencyExchangeRate CurrentExchangeRate { get; set; }
    }
}
