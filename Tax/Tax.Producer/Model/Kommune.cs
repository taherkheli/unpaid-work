using System;
using System.Collections.Generic;
using System.Linq;

namespace Tax.Producer.Model
{
  public class Kommune
  {
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<Model.TaxRule> TaxRules { get; set; }

    public double Calculate(DateTime d)
    {
      var winningRule = TaxRules.Where(r => r.IsApplicable(d))
                                 .OrderBy(r => r.Type);
      return winningRule.First().Rate;
    }
  }
}
