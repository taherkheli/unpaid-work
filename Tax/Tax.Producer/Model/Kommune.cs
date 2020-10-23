using System;
using System.Collections.Generic;


namespace Tax.Producer.Model
{
  public class Kommune
  {
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<Model.TaxRule> TaxRules { get; set; }
  }
}
