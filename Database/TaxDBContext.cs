using Microsoft.EntityFrameworkCore;
using TaxDB.Models;

namespace TaxDB
{
    public class TaxDBContext : DbContext
    {
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<TaxRate> TaxRates { get; set; }

        public TaxDBContext(DbContextOptions<TaxDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
