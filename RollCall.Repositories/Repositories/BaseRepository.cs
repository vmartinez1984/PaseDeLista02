using RollCall.Repositories.Contexts;

namespace RollCall.Repositories.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _appDbContext;

        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
