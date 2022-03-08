using System;

namespace TaxClient.Data
{
    public class TaxRateData
    {
        public int Id { get; set; }
        public Period Period { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public double Rate { get; set; }
    }
}
