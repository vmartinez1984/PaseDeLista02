using RollCall.Core.Entities;
using RollCall.Core.Interfaces;
using RollCall.Repositories.Contexts;

namespace RollCall.Repositories.Repositories
{
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        public AddressRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<int> AddAsync(Address entity)
        {
            _appDbContext.Addresses.Add(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
