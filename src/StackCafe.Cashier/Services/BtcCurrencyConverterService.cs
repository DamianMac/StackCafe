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
            return amount * AudToBtc;
        }

        public decimal ConvertToAUD(decimal amount)
        {
            return amount / AudToBtc;
        }

        public decimal AudToBtc { get; set; }
    }
}
