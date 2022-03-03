using System;

namespace TaxDB.Models
{
    public enum Period
    {
        DAILY,
        WEEKLY,
        MONTHLY,
        YEARLY
    }

    public class TaxRate
    {
        public int Id { get; set; }
        public int MunicipalityId { get; set; }
        public Municipality Municipality { get; set; }
        public Period Period { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public double Rate { get; set; }
    }
}
