using System;

namespace TaxCalculator
{
  public class TaxRule
  {
    public TaxRule(DateTime start, DateTime end, RuleType type, double rate)
    {
      //TODO: validate input here to ensure tax rule is fully valid
      Start = start;
      End = end;
      Type = type;
      Rate = rate;
    }

    public DateTime Start { get; private set; }

    public DateTime End { get; private set; }

    public RuleType Type { get; set; }
    
    public double Rate { get; private set; }

    public bool IsApplicable(DateTime d)
    {
      if ((d.CompareTo(Start) >= 0) && (d.CompareTo(End) <= 0))
        return true;

      return false;
    }
  }
}
