using Microsoft.EntityFrameworkCore;
using MunicipalityTax.Domain;

namespace MunicipalityTax.Data
{
  public class MunicipalityContext : DbContext
  {
    public DbSet<Municipality> Municipalities { get; set; }

    public DbSet<TaxRule> TaxRules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MunicipalityTaxData";
      optionsBuilder.UseSqlServer(connectionString);
    }
  }
}
