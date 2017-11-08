using System;
using Nimbus.MessageContracts;
using StackCafe.MessageContracts.Events;

namespace StackCafe.MessageContracts.Requests
{
    public class GetCurrentExchangeRateRequest : IBusRequest<GetCurrentExchangeRateRequest, GetCurrentExchangeRateResponse>
    {
        public GetCurrentExchangeRateRequest(Currency fromCurrency, Currency toCurrency)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
        }

        public Currency ToCurrency { get; set; }
        public Currency FromCurrency { get; set; }


    }
}