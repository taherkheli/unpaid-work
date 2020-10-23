using System;

namespace Tax.API.Model
{
  public class Kommune
  {
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int TaxRuleCount { get; set; }
  }
}
