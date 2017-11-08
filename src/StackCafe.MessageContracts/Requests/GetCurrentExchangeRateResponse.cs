using Nimbus.MessageContracts;
using StackCafe.MessageContracts.Events;

namespace StackCafe.MessageContracts.Requests
{
    public class GetCurrentExchangeRateResponse : IBusResponse
    {
        public GetCurrentExchangeRateResponse(CurrencyExchangeRate currentExchangeRate)
        {
            CurrentExchangeRate = currentExchangeRate;
        }

        public CurrencyExchangeRate CurrentExchangeRate { get; set; }
    }
}
