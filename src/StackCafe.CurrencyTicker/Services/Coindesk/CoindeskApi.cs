using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCafe.CurrencyTicker.Services.Coindesk
{
    public class Time
    {
        public string updated { get; set; }
        public DateTimeOffset updatedISO { get; set; }
        public string updateduk { get; set; }
    }

    public class USD
    {
        public string code { get; set; }
        public string rate { get; set; }
        public string description { get; set; }
        public double rate_float { get; set; }
    }

    public class AUD
    {
        public string code { get; set; }
        public string rate { get; set; }
        public string description { get; set; }
        public double rate_float { get; set; }
    }

    public class Bpi
    {
        public USD USD { get; set; }
        public AUD AUD { get; set; }
    }

    public class CoindeskApiResponseObject
    {
        public Time time { get; set; }
        public string disclaimer { get; set; }
        public Bpi bpi { get; set; }
    }
}
