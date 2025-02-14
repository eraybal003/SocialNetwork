using Data.Context;
using Data.IRepositories;
using Domain.Entities;

namespace Data.Repositories;
public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
