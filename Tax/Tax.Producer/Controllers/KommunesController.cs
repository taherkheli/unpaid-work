using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tax.API.Services;

namespace Tax.API.Controllers
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
          TaxRuleCount = k.TaxRules.Count
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
        Name = kommune.Name,
        TaxRuleCount = kommune.TaxRules.Count
      };

      return Ok(kommuneDto);
    }
  }
}
