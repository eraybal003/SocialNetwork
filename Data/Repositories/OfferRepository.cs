using Data.Context;
using Data.IRepositories;
using Domain.Entities;

namespace Data.Repositories;

public class OfferRepository : Repository<Offer>, IOfferRepository
{
    public OfferRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
