using MunicipalityTax.Data;
using MunicipalityTax.Domain;
using System;
using System.Linq;

namespace ConsoleApp
{
  class Program
  {
    private static readonly MunicipalityContext context = new MunicipalityContext();

    static void Main()
    {
      //context.Database.EnsureCreated();
      //GetMunicipalities("Before Add:");
      //AddMunicipality();
      //GetMunicipalities("After Add:");
      //Console.WriteLine("Press any key...");
      //Console.ReadKey();
    }

    private static void GetMunicipalities(string text)
    {
      var municipalities = context.Municipalities.ToList();
      Console.WriteLine($"{text}: Municipality count is {municipalities.Count}");

      foreach (var m in municipalities)      
        Console.WriteLine(m.Name);      
    }

    private static void AddMunicipality()
    {
      var m = new Municipality(){ Name = "Sønderborg"};
      context.Add(m);
      context.SaveChanges();
    }
  }
}
