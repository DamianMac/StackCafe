using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCafe.Cashier.Services
{
    class BtcCurrencyConverterService : IBtcCurrencyConverterService
    {
        public decimal ConvertToBTC(decimal amount)
        {
            if (!AudToBtc.HasValue)
                throw new Exception("Sorry but we don't have a BTC conversion rate");

            return amount * AudToBtc.Value;
        }

        public decimal ConvertToAUD(decimal amount)
        {
            if (!AudToBtc.HasValue)
                throw new Exception("Sorry but we don't have a BTC conversion rate");

            return amount / AudToBtc.Value;
        }

        public decimal? AudToBtc { get; set; }
    }
}
