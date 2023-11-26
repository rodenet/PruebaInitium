using PruebaInitium.Domain.Entities;
using PruebaInitium.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInitium.Infrastructure.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        private readonly AthleteContext _context;

        public EntryRepository(AthleteContext context)
        {
            _context = context;
        }

        public async Task<Entry> Insert(Entry entry)
        {
            await _context.Entries.AddAsync(entry);
            await _context.SaveChangesAsync();
            return entry;
        }
    }
}
