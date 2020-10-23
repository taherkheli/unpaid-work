using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tax.Producer.Entities;

namespace Tax.Producer.Services
{
  public interface IKommuneRepo
  {
    Task<Kommune> GetKommuneAsync(Guid id);

    Task<IEnumerable<Kommune>> GetKommunesAsync();
  }
}
