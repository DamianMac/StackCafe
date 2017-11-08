using Nimbus.Handlers;
using StackCafe.CurrencyHistory.Services;
using StackCafe.MessageContracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCafe.CurrencyHistory.Rules.WhenSomeoneRequestsCurrentExchangeRate
{
    public class ReturnCurrentExchangeRate : IHandleRequest<GetCurrentExchangeRateRequest, GetCurrentExchangeRateResponse>
    {
        readonly IExchangeRateRepository _exchangeRateRepository;
        public ReturnCurrentExchangeRate(IExchangeRateRepository exchangeRateRepository)
        {
            this._exchangeRateRepository = exchangeRateRepository;
        }
        public Task<GetCurrentExchangeRateResponse> Handle(GetCurrentExchangeRateRequest request)
        {
            return Task.FromResult(new GetCurrentExchangeRateResponse(_exchangeRateRepository.GetLatest(request.FromCurrency, request.ToCurrency)));
        }
    }
}
