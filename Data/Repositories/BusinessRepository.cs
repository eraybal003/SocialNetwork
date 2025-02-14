using Data.Context;
using Data.IRepositories;
using Domain.Entities;

namespace Data.Repositories;

public class BusinessRepository : Repository<Business>, IBusinessRepository
{
    public BusinessRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
