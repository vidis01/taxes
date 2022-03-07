using System;
using TaxDB.Models;

namespace TaxAPI.Models
{
    public class TaxRateDto
    {
        public int Id { get; set; }
        public Period Period { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public double Rate { get; set; }
    }
}
