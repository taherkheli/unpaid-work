using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tax.API.Entities
{
  [Table("TaxRule")]
  public class TaxRule
  {
    [Key]
    public Guid Id { get; set; }

    [Required]
    public DateTime Start { get; set; }

    [Required]
    public DateTime End { get; set; }

    [Required]
    public RuleType Type { get; set; }

    [Required]
    public double Rate { get; set; }

    public Guid KommuneId { get; set; }

    public Kommune Kommune { get; set; }
  }
}
