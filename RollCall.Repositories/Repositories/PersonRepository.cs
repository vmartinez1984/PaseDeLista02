using Microsoft.EntityFrameworkCore;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces;
using RollCall.Repositories.Contexts;

namespace RollCall.Repositories.Repositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public PersonRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<int> AddAsync(Person entity)
        {
            _appDbContext.People.Add(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Person>> GetAsync()
        {
            List<Person> entities;

            entities = await _appDbContext.People.ToListAsync();

            return entities;
        }

        public Task UpdateAsync(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
