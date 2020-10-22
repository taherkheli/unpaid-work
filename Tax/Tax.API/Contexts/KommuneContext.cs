using Microsoft.EntityFrameworkCore;
using System;
using Tax.API.Entities;

namespace Tax.API.Contexts
{
  public class KommuneContext : DbContext
  {
    public DbSet<Kommune> Kommunes { get; set; }
    public DbSet<TaxRule> TaxRules { get; set; }

    public KommuneContext(DbContextOptions<KommuneContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //read input data from a json or csv file here??

      modelBuilder.Entity<Kommune>().HasData(
        new Kommune()
        {
          Id = Guid.Parse("B5FD3AC8-E9C1-42F3-B3B2-451955D157B7"),
          Name = "Copenhagen"
        },
        new Kommune()
        {
          Id = Guid.Parse("5AE87A5C-E9E1-4A6F-9941-17E072641704"),
          Name = "Sønderborg"
        },
        new Kommune()
        {
          Id = Guid.Parse("0870EF4E-5D89-4CB4-95B8-A420463744BA"),
          Name = "Vejle"
        }
      );

      modelBuilder.Entity<TaxRule>().HasData(
        new TaxRule()
        {
          Id = Guid.Parse("6EA16E6C-92FC-405E-8A31-8F59AB80FD61"),
          Start = new DateTime(2016, 01, 01),
          End = new DateTime(2016, 12, 31),
          Type = RuleType.Yearly,
          Rate = 0.2,
          KommuneId = Guid.Parse("B5FD3AC8-E9C1-42F3-B3B2-451955D157B7")
        },
        new TaxRule()
        {
          Id = Guid.Parse("E0967C75-DD92-482F-B5EC-F7F83F2FA998"),
          Start = new DateTime(2016, 05, 01),
          End = new DateTime(2016, 5, 31),
          Type = RuleType.Monthly,
          Rate = 0.4,
          KommuneId = Guid.Parse("B5FD3AC8-E9C1-42F3-B3B2-451955D157B7")
        },
        new TaxRule()
        {
          Id = Guid.Parse("F9A8F089-A077-4169-A377-35D0CA259EFF"),
          Start = new DateTime(2016, 01, 01),
          End = new DateTime(2016, 1, 1),
          Type = RuleType.Daily,
          Rate = 0.1,
          KommuneId = Guid.Parse("B5FD3AC8-E9C1-42F3-B3B2-451955D157B7")
        },
        new TaxRule()
        {
          Id = Guid.Parse("BE07F1E2-64D5-4BA6-9687-6BE45ABE82D5"),
          Start = new DateTime(2016, 12, 25),
          End = new DateTime(2016, 12, 25),
          Type = RuleType.Daily,
          Rate = 0.1,
          KommuneId = Guid.Parse("B5FD3AC8-E9C1-42F3-B3B2-451955D157B7")
        }
      );

      base.OnModelCreating(modelBuilder);
    }
  }
}
