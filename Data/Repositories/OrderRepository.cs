using Data.Context;
using Data.IRepositories;
using Domain.Entities;

namespace Data.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
