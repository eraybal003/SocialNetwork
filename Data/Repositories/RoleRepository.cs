using Data.Context;
using Data.IRepositories;
using Domain.Entities;

namespace Data.Repositories;
public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
