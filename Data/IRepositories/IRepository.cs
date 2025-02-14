using Domain.Common;
using System.Linq.Expressions;

namespace Data.IRepositories;

public interface IRepository<TEntity> where TEntity: EntityBase
{
    IQueryable<TEntity> GetAll(bool withDeleted = false);
    TEntity? FindOne(Expression<Func<TEntity, bool>> expression);
    IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    bool Any(Expression<Func<TEntity, bool>> expression);
}
