using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tax.API.Services;

namespace Tax.API.Controllers
{
  [ApiController]
  [Route("api/Kommunes")]
  public class KommunesController : ControllerBase
  {
    private readonly IKommuneRepo _kommuneRepo;

    private readonly JsonSerializerOptions options = new JsonSerializerOptions
    {
      ReferenceHandling = ReferenceHandling.Preserve
    };

    public  KommunesController(IKommuneRepo kommuneRepo)
    {
      _kommuneRepo = kommuneRepo ?? throw new ArgumentException(nameof(kommuneRepo));
    }

    [HttpGet]
    public async Task<IActionResult> GetKommunes()
    {
      //https://github.com/dotnet/runtime/issues/30938#issuecomment-576923631

      var kommuneEntities = await _kommuneRepo.GetKommunesAsync();

      return Ok(JsonSerializer.Serialize(kommuneEntities, options));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetKommune(Guid id)
    {
      var kommune = await _kommuneRepo.GetKommuneAsync(id);

      if (kommune == null)
        return NotFound();

      return Ok(JsonSerializer.Serialize(kommune, options));
    }
  }
}
