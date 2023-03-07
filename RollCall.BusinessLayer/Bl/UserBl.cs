using AutoMapper;
using RollCall.Core.Dtos;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces;

namespace RollCall.BusinessLayer.Bl
{
    public class UserBl : BaseBl, IUserBl
    {
        public UserBl(IRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<int> AddAsync(UserDtoIn item)
        {
            Person personEntity;
            User userEntity;

            personEntity = _mapper.Map<Person>(item);
            userEntity = _mapper.Map<User>(item);            
            userEntity.Person = personEntity;
            userEntity.Id = await _repository.User.AddAsync(userEntity);

            return userEntity.Id;            
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.User.DeleteAsync(id);
        }

        public async Task<List<UserDto>> GetAsync()
        {
            List<UserDto> list;
            List<User> entities;

            entities = await _repository.User.GetAsync();
            list = _mapper.Map<List<UserDto>>(entities);

            return list;
        }

        public async Task<UserDto> GetAsync(int id)
        {
            UserDto dto;
            User entity;

            entity = await _repository.User.GetAsync(id);
            dto = _mapper.Map<UserDto>(entity);

            return dto;
        }

        public async Task UpdateAsync(UserDtoIn item, int id)
        {
            User user;

            user = await _repository.User.GetAsync(id);
            user.Email = item.Email;    
            user.Password = item.Password;
            user.Person.Name = item.Name;
            user.Person.LastName = item.LastName;
            user.Person.Birthday = item.Birthday;
            user.Person.Genere = item.Genere;

            await _repository.User.UpdateAsync(user);
        }
    }
}
