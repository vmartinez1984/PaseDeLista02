using Microsoft.EntityFrameworkCore;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces;
using RollCall.Repositories.Contexts;

namespace RollCall.Repositories.Repositories;
public class RoleRepository : BaseRepository, IRoleRepository
{
    public RoleRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<List<Role>> GetAsync()
    {
        List<Role> roles;

        roles = await _appDbContext.Roles.ToListAsync();

        return roles;
    }
}