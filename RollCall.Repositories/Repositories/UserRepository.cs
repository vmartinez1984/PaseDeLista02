using Microsoft.EntityFrameworkCore;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces;
using RollCall.Repositories.Contexts;

namespace RollCall.Repositories.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<int> AddAsync(User entity)
        {
            _appDbContext.Users.Add(entity);
            await _appDbContext.SaveChangesAsync(); 

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            User entity;

            entity = await _appDbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            entity.IsActive = false;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            User entity;

            entity = await _appDbContext.Users
                .Include(x=> x.Person)
                .Include(x=> x.Role)
                .Where(x=> x.Id == id).FirstOrDefaultAsync(); 

            return entity;
        }

        public async Task<List<User>> GetAsync()
        {
            List<User> list;

            list = await _appDbContext.Users
                .Include(x => x.Person)
                .Include(x => x.Role)
                .Where(x => x.IsActive).ToListAsync();

            return list;
        }

        public async Task<User> GetAsync(string email)
        {
            User entity;

            entity = await _appDbContext.Users
                .Include(x => x.Person)
                .Include(x => x.Role)
                .Where(x => x.Email == email).FirstOrDefaultAsync();

            return entity;
        }

        public async Task UpdateAsync(User entity)
        {
            _appDbContext.Users.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}
