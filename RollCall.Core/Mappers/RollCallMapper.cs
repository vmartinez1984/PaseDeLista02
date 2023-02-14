using AutoMapper;
using RollCall.Core.Dtos;
using RollCall.Core.Entities;

namespace RollCall.Core.Mappers
{
    public class RollCallMapper: Profile
    {
        public RollCallMapper() 
        {
            CreateMap<PersonDtoIn, Person>();
            CreateMap<Person, PersonDto>();
        }
    }
}