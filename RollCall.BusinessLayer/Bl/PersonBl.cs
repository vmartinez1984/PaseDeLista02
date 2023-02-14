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

        public Task<int> AddAsync(PersonDtoIn item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PersonDto>> GetAsync()
        {
            List<Person> entities;
            List<PersonDto> list;

            entities = await _repository.Person.GetAsync();
            list = _mapper.Map<List<PersonDto>>(entities);

            return list;
        }

        public Task<PersonDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PersonDtoIn item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
