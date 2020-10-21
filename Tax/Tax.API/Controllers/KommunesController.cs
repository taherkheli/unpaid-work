using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
      // https://github.com/dotnet/runtime/issues/30938#issuecomment-576923631
      // TODO: fix this      
      //var options = new JsonSerializerOptions
      //{
      //  ReferenceHandling = ReferenceHandling.Preserve
      //};
      //string json = JsonSerializer.Serialize(objectWithLoops, options);

      var kommuneEntities = await _kommuneRepo.GetKommunesAsync();

      return Ok(kommuneEntities);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetKommune(Guid id)
    {
      var kommune = await _kommuneRepo.GetKommuneAsync(id);

      if (kommune == null)
        return NotFound();

      return Ok(kommune);
    }
  }
}
