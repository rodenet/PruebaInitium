using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaInitium.API.Models;
using PruebaInitium.Application.DTO;
using PruebaInitium.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaInitium.API.Controllers
{
    [ApiController]
    [Route("api/athlete")]
    [Authorize]
    public class AthleteController : ControllerBase
    {
        private readonly ILogger<AthleteController> _logger;

        private readonly IAthleteService _athleteService;
        private readonly IMapper _mapper;

        public AthleteController(ILogger<AthleteController> logger, IAthleteService athleteService, IMapper mapper)
        {
            _logger = logger;
            _athleteService = athleteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AthleteDTO>> GetAll()
        {
            _logger.LogInformation($"Entering AthleteController GetAll method");

            try
            {
                var athletes = await _athleteService.GetAll();
                return athletes;
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation($"Exiting AthleteControllet GetAll method");
            }
        }

        [HttpPost]
        public async Task<AthleteDTO> Insert([FromBody] InsertAthleteDTO model)
        {
            _logger.LogInformation($"Entering AthleteController Insert method");

            try
            {
                var athlete = await _athleteService.Insert(model);
                return athlete;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation($"Exiting AthleteControllet Insert method");
            }
        }

        [HttpPost("{id}/entry")]
        public async Task<AthleteDTO> InsertEntry([FromRoute] Guid id, [FromBody] InsertEntryModel model)
        {
            _logger.LogInformation($"Entering AthleteController InsertEntry method");

            try
            {
                var dto = _mapper.Map<InsertEntryDTO>(model);
                dto.AthleteId = id;
                var athlete = await _athleteService.InsertEntry(dto);
                return athlete;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation($"Exiting AthleteControllet InsertEntry method");
            }
        }
    }
}
