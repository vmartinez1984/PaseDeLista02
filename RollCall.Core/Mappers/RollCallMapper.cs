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

            CreateMap<PersonDtoIn, Address>();

            CreateMap<PagerDtoIn, PagerEntity>();

            CreateMap<PagerEntity,PagerDto>();

            CreateMap<UserDtoIn, Person>();

            CreateMap<UserDtoIn, User>();

            CreateMap<User, UserDto>()
                .ForMember(dto => dto.Name, x => x.MapFrom(entity => entity.Person.Name))
                .ForMember(dto => dto.LastName, x => x.MapFrom(entity => entity.Person.LastName))
                .ForMember(dto => dto.Birthday, x => x.MapFrom(entity => entity.Person.Birthday))
                .ForMember(dto => dto.Genere, x => x.MapFrom(entity => entity.Person.Genere))
                .ForMember(dto => dto.RoleId, x => x.MapFrom(entity => entity.Role.Id))
                .ForMember(dto => dto.RoleName, x => x.MapFrom(entity => entity.Role.Name))
                ;

            CreateMap<Role, RoleDto>();
        }
    }
}