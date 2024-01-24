using System;
using System.Linq.Expressions;

namespace SPWCircularofLux.Data.IRepositories
{
	public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity?> GetByIdAsync(long id);
        Task<IEnumerable<TEntity?>> GetAllAsync();
        IEnumerable<TEntity?> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        IQueryable<TEntity> FindAll();
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> Include(Expression<Func<TEntity, object>> expression);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
    }
}

