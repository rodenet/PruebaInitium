using AutoMapper;
using PruebaInitium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInitium.Application.DTO.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Athlete, AthleteDTO>().ForMember(x => x.Country, x => x.MapFrom(e => e.Country.Code));
            CreateMap<InsertEntryDTO, Entry>();
        }
    }
}
