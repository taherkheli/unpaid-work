using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tax.API.Entities;

namespace Tax.API.Services
{
  public interface IKommuneRepo
  {
    Task<Kommune> GetKommuneAsync(Guid id);

    Task<IEnumerable<Kommune>> GetKommunesAsync();
  }
}
