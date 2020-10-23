using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tax.Producer.Contexts;
using Tax.Producer.Entities;

namespace Tax.Producer.Services
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
      var kommune = await _context.Kommunes.Include( k => k.TaxRules).FirstOrDefaultAsync(k => k.Id == id);
      return kommune;
    }

    public async Task<IEnumerable<Kommune>> GetKommunesAsync()
    {
      var kommunes = await _context.Kommunes.Include(k => k.TaxRules).ToListAsync();
      return kommunes;
    }
  }
}
