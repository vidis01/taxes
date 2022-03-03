using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaxDB.Models
{
    public class Municipality
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public List<TaxRate> TaxRates { get; set; }
    }
}
