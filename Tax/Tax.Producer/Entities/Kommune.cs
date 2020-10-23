using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tax.Producer.Entities
{
  [Table("Kommune")]
  public class Kommune
  {
    public Kommune()
    {
      TaxRules = new List<TaxRule>();
    }

    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; }

    public List<TaxRule> TaxRules { get; set; }
  }
}
