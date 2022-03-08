using System;

namespace TaxClient.Data
{
    public class RequestData
    {
        public string Municipality { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
