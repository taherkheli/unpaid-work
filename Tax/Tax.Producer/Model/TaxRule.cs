using System;
using Tax.Producer.Entities;

namespace Tax.Producer.Model
{
  public class TaxRule
  {
    public Guid Id { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public RuleType Type { get; set; }

    public double Rate { get; set; }

    public bool IsApplicable(DateTime d)
    {
      if ((d.CompareTo(Start) >= 0) && (d.CompareTo(End) <= 0))
        return true;

      return false;
    }
  }
}