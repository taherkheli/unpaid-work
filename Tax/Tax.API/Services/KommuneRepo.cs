using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tax.API.Contexts;
using Tax.API.Entities;

namespace Tax.API.Services
{
  public class KommuneRepo : IKommuneRepo
  {
    private readonly KommuneContext _context;

    public KommuneRepo(KommuneContext context)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Kommune> GetKommuneAsync(Guid id)
    {
      var k = await _context.Kommunes.Include( k => k.TaxRules).FirstOrDefaultAsync(k => k.Id == id);

      //return await _context.Kommunes.Include(k => k.TaxRules).FirstOrDefaultAsync(k => k.Id == id);
      // TODO: works uptil here but why do I get an exception in the browser? Whats wrong in Controller serving it?
      return k;
    }

    public async Task<IEnumerable<Kommune>> GetKommunesAsync()
    {
      var kommunes = await _context.Kommunes.Include(k => k.TaxRules).ToListAsync();

      //return await _context.Kommunes.Include( k => k.TaxRules).ToListAsync();
      // TODO: works uptil here but why do I get an exception in the browser? Whats wrong in Controller serving it?
      return kommunes;
    }
  }
}
