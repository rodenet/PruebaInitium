using PruebaInitium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInitium.Domain.Repositories
{
    public interface ICountryRepository
    {
        Task<Country> GetByCode(string code);
    }
}
