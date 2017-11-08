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
            return amount * GetAUDInBTC();
        }

        public decimal ConvertToAUD(decimal amount)
        {
            return amount / GetAUDInBTC();
        }

        public decimal GetAUDInBTC()
        {
            return 1M / 9000M;
        }
    }
}
