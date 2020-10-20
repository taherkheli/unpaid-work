using System;

namespace MunicipalityTax.Domain
{
  public class TaxRule
  {
    public int Id { get; set; }

    public int MunicipalityId { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public RuleType Type { get; set; }
    
    public double Rate { get; set; }
  }
}
