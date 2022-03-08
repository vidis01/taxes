using System;

namespace TaxClient.Data
{
    public class NewTaxRateData
    {
        public string Municipality { get; set; }
        public Period Period { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public double Rate { get; set; }
    }
}
