using Data.Context;
using Data.IRepositories;
using Domain.Common;
using System.Linq.Expressions;

namespace Data.Repositories;

public class Repository<TEntity>(AppDbContext appDbContext):IRepository<TEntity> where TEntity: EntityBase
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public void Add(TEntity entity)
    {
        entity.Id = Guid.NewGuid();
        entity.CreateTime = DateTime.Now;
        _appDbContext.Set<TEntity>().Add(entity);
        _appDbContext.SaveChanges();
    }

    public bool Any(Expression<Func<TEntity, bool>> expression)
    {
        return _appDbContext.Set<TEntity>().Any(expression);
    }

    public void Delete(TEntity entity)
    {
        entity.DeleteTime = DateTime.Now;
        _appDbContext.Set<TEntity>().Update(entity);
        _appDbContext.SaveChanges();

    }

    public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression)
    {
        return _appDbContext.Set<TEntity>().Where(expression);
    }

    public TEntity? FindOne(Expression<Func<TEntity, bool>> expression)
    {
        return _appDbContext.Set<TEntity>().SingleOrDefault(expression);
    }

    public IQueryable<TEntity> GetAll(bool withDeleted = false)
    {
        if (withDeleted)
        {
            return _appDbContext.Set<TEntity>();
        }
        else
        {
            return _appDbContext.Set<TEntity>().Where<TEntity>(x => x.DeleteTime == null);
        }
    }

    public void Update(TEntity entity)
    {
        entity.UpdateTime = DateTime.Now;
        _appDbContext.Set<TEntity>().Update(entity);
        _appDbContext.SaveChanges();
    }
}
