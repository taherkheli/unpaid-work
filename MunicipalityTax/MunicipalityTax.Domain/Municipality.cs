using System.Collections.Generic;

namespace MunicipalityTax.Domain
{
  public class Municipality
  {
    public Municipality()
    {
      TaxRules = new List<TaxRule>();
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public List<TaxRule> TaxRules { get; set; }
  }
}
