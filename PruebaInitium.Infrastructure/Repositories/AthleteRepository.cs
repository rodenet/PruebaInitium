using Microsoft.EntityFrameworkCore;
using PruebaInitium.Domain.Entities;
using PruebaInitium.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInitium.Infrastructure.Repositories
{
    public class AthleteRepository : IAthleteRepository
    {
        private readonly AthleteContext _context;

        public AthleteRepository(AthleteContext context)
        {
            _context = context;
        }

        public async Task<Athlete> Get(Guid id)
        {
            return await _context.Athletes.Include(x => x.Country).Include(x => x.Entries).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Athlete>> GetAll()
        {
            return await _context.Athletes.Include(x => x.Country).Include(x => x.Entries).ToListAsync();
        }

        public async Task<Athlete> Insert(Athlete athlete)
        {
            await _context.Athletes.AddAsync(athlete);
            await _context.SaveChangesAsync();
            return athlete;
        }
    }
}
