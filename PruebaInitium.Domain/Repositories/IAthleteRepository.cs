using PruebaInitium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInitium.Domain.Repositories
{
    public interface IAthleteRepository
    {
        Task<IEnumerable<Athlete>> GetAll();
        
        Task<Athlete> Get(Guid id);

        Task<Athlete> Insert(Athlete athlete);
    }
}
