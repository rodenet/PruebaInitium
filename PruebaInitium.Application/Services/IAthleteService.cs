using PruebaInitium.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInitium.Application.Services
{
    public interface IAthleteService
    {
        Task<IEnumerable<AthleteDTO>> GetAll();

        Task<AthleteDTO> Get(Guid id);

        Task<AthleteDTO> Insert(InsertAthleteDTO model);

        Task<AthleteDTO> InsertEntry(InsertEntryDTO model);
    }
}
