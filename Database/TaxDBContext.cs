using Microsoft.EntityFrameworkCore;
using TaxDB.Models;

namespace TaxDB
{
    public class TaxDBContext : DbContext
    {
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<TaxRate> TaxRates { get; set; }

        public TaxDBContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=TaxDB;Trusted_Connection=True");            
        }
    }
}
