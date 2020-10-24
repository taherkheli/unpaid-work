using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tax.Producer.Services;

namespace Tax.Producer.Controllers
{
  [ApiController]
  [Route("api/Kommunes")]
  public class KommunesController : ControllerBase
  {
    private readonly IKommuneRepo _kommuneRepo;

    public  KommunesController(IKommuneRepo kommuneRepo)
    {
      _kommuneRepo = kommuneRepo ?? throw new ArgumentException(nameof(kommuneRepo));
    }

    [HttpGet]
    public async Task<IActionResult> GetKommunes()
    {
      var kommunes = await _kommuneRepo.GetKommunesAsync();

      if (kommunes == null)
        return Ok(new List<Model.Kommune>());

      //TODO: all this clutter needs to move elsewhere
      var kommunesDto = new List<Model.Kommune>();

      foreach (var k in kommunes)
      {
        kommunesDto.Add(new Model.Kommune()
        {
          Id = k.Id,
          Name = k.Name,
          TaxRules = TransformTaxRules(k.TaxRules),
        });
      }

      return Ok(kommunesDto);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetKommune(Guid id)
    {
      var kommune = await _kommuneRepo.GetKommuneAsync(id);

      if (kommune == null)
        return NotFound();

      //TODO: all this clutter needs to move elsewhere
      var kommuneDto = new Model.Kommune
      {
        Id = kommune.Id,
        Name = kommune.Name
      };

      kommuneDto.TaxRules = TransformTaxRules(kommune.TaxRules);

      return Ok(kommuneDto);
    }

    [HttpPost]
    [Route("{name}/{date}")]
    public async Task<IActionResult> ApplicableTaxRate(string name, string date)
    {
      DateTime day;
      var delimiters = new char[] { '.', '-' };

      if (String.IsNullOrWhiteSpace(date) || (date.Split(delimiters).Length != 3))
        return BadRequest();
      else
      {
        var pieces = date.Split(delimiters);
        day = new DateTime(Int32.Parse(pieces[0]), Int32.Parse(pieces[1]), Int32.Parse(pieces[2]));
      }

      var kommunes = await _kommuneRepo.GetKommunesAsync();
      var kommune =  kommunes.FirstOrDefault(kommunes => String.Equals(name, kommunes.Name, StringComparison.OrdinalIgnoreCase));

      if ((kommune == null) || (kommune.TaxRules == null))
        return NotFound();

      var kommune_BLL = new Model.Kommune
      {
        Id = kommune.Id,
        Name = kommune.Name
      };
      kommune_BLL.TaxRules = TransformTaxRules(kommune.TaxRules);     

      return Ok(kommune_BLL.Calculate(day));
    }

    private List<Model.TaxRule> TransformTaxRules(List<Entities.TaxRule> rules)
    {
      var result = new List<Model.TaxRule>();

      foreach (var r in rules)
      {
        result.Add(new Model.TaxRule() { 
          Id = r.Id,
          Start = r.Start,
          End = r.End,
          Rate = r.Rate,
          Type = r.Type
        });
      }

      return result;
    }

  }
}
