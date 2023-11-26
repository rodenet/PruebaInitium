using AutoMapper;
using PruebaInitium.Application.DTO;
using PruebaInitium.Domain.Entities;
using PruebaInitium.Domain.Exceptions;
using PruebaInitium.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInitium.Application.Services
{
    public class AthleteService : IAthleteService
    {
        private readonly IAthleteRepository _athleteRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IEntryRepository _entryRepository;
        private readonly IMapper _mapper;

        public AthleteService(
            IAthleteRepository athleteRepository,
            ICountryRepository countryRepository,
            IEntryRepository entryRepository,
            IMapper mapper
        )
        {
            _athleteRepository = athleteRepository;
            _countryRepository = countryRepository;
            _entryRepository = entryRepository;
            _mapper = mapper;
        }

        public async Task<AthleteDTO> Get(Guid id)
        {
            return _mapper.Map<AthleteDTO>(await _athleteRepository.Get(id));
        }

        public async Task<IEnumerable<AthleteDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<AthleteDTO>>(await _athleteRepository.GetAll());
        }

        public async Task<AthleteDTO> Insert(InsertAthleteDTO model)
        {
            if(model is null || string.IsNullOrWhiteSpace(model.Name))
            {
                throw new EmptyNameException();
            }

            var country = await _countryRepository.GetByCode(model.Country);

            if(country is null)
            {
                throw new CountryDoesNotExistsException();
            }

            return _mapper.Map<AthleteDTO>(await _athleteRepository.Insert(new Athlete()
            {
                CountryId = country.Id,
                Name = model.Name
            }));
        }

        public async Task<AthleteDTO> InsertEntry(InsertEntryDTO model)
        {

            var athlete = await _athleteRepository.Get(model.AthleteId);

            if(athlete is null)
            {
                throw new AthleteDoesNotExistsException();
            }

            if(model.Weight <= 0)
            {
                throw new WeightLessEqualZeroException();
            }

            await _entryRepository.Insert(_mapper.Map<Entry>(model));
            return _mapper.Map<AthleteDTO>(await _athleteRepository.Get(model.AthleteId));
        }
    }
}
