using Microsoft.EntityFrameworkCore;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces;
using RollCall.Repositories.Contexts;

namespace RollCall.Repositories.Repositories
{
    internal class HolidayRepository : BaseRepository, IHolidayRepository
    {
        public HolidayRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<int> AddAsync(Holiday entity)
        {
            _appDbContext.Holiday.Add(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            Holiday entity;

            entity = await GetAsync(id);
            entity.IsActive = false;           

            await UpdateAsync(entity);
        }

        public async Task<List<Holiday>> GetAsync()
        {
            List<Holiday> entitites;

            entitites = await _appDbContext.Holiday.Where(x => x.IsActive).ToListAsync();

            return entitites;            
        }

        public async Task<Holiday> GetAsync(int id)
        {
            Holiday entity;

            entity = await _appDbContext.Holiday.Where(x => x.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public async Task UpdateAsync(Holiday entity)
        {
            _appDbContext.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}
