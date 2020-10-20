using System;
using System.Collections.Generic;
using System.Linq;

namespace TaxCalculator
{
  public class Kommune
  {
    private readonly string _name; 
    private readonly IEnumerable<TaxRule> _taxRules;

    public Kommune(string name, IEnumerable<TaxRule> taxRules)
    {
      _name = name;
      _taxRules = taxRules;
    }

    public string Name { get => _name; }

    public IEnumerable<TaxRule> TaxRules { get => _taxRules; }

    public double Calculate(DateTime d)
    {
      var winningRule = _taxRules.Where(r => r.IsApplicable(d))
                                 .OrderBy(r => r.Type);
      return winningRule.First().Rate;
    }
  }
}
