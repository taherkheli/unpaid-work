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
  }
}