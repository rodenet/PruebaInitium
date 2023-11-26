using AutoMapper;
using PruebaInitium.Application.DTO;

namespace PruebaInitium.API.Models.Mapper
{
    public class ApiMapperProfile : Profile
    {
        public ApiMapperProfile()
        {
            CreateMap<InsertEntryModel, InsertEntryDTO>();
        }
    }
}
