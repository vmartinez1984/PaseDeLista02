using AutoMapper;
using RollCall.Core.Dtos;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces;

namespace RollCall.BusinessLayer.Bl
{
    internal class PersonBl : BaseBl, IPersonBl
    {
        public PersonBl(IRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<int> AddAsync(PersonDtoIn item)
        {
            Person person;
            int id;

            person = _mapper.Map<Person>(item);
            person.Addresses.Add(_mapper.Map<Address>(item));
            id = await _repository.Person.AddAsync(person);

            return id;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagerDto> GetAsync(PagerDtoIn pagerDtoIn)
        {
            List<Person> entities;
            PagerEntity pagerEntity;
            PagerDto pagerDto;

            pagerEntity = _mapper.Map<PagerEntity>(pagerDtoIn);
            entities = await _repository.Person.GetAsync(pagerEntity);
            pagerDto = _mapper.Map<PagerDto>(pagerEntity);
            pagerDto.List = _mapper.Map<List<PersonDto>>(entities);

            return pagerDto;
        }

        public async Task<PersonDto> GetAsync(int id)
        {
            Person entity;
            PersonDto dto;
            Address address;

            entity = await _repository.Person.GetAsync(id);
            dto = _mapper.Map<PersonDto>(entity);
            address = entity.Addresses.FirstOrDefault();
            if(address != null)
            {
            dto.StreetAndNumber = address.StreetAndNumber;
            dto.ZipCode = address.ZipCode;
            dto.Settlement = address.Settlement;
            dto.Town = address.Town;
            dto.State = address.State;
            dto.AddressId = address.Id;
            }

            return dto;
        }

        public async Task UpdateAsync(PersonDtoIn item, int id)
        {
            Person entity;
            Address address;

            entity = _mapper.Map<Person>(item);
            address = _mapper.Map<Address>(item);
            address.PersonId = id;
            address.Id = item.AddressId;            
            entity.Addresses.Add(address);            
            entity.Id = id;

            await _repository.Person.UpdateAsync(entity);
        }
    }
}
