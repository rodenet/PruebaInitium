using PruebaInitium.Domain.Entities;
using PruebaInitium.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInitium.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AthleteContext _context;

        public CountryRepository(AthleteContext context)
        {
            _context = context;
        }

        public Task<Country> GetByCode(string code)
        {
            return Task.FromResult(_context.Countries.FirstOrDefault(x => x.Code == code));
        }
    }
}
