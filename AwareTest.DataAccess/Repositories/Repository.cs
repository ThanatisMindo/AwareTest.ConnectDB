using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using SPWCircularofLux.Data.IRepositories;

namespace SPWCircularofLux.Data.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public Repository(DbContext context)
        {
            this.Context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }     

        public IEnumerable<TEntity?> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity?>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public ValueTask<TEntity?> GetByIdAsync(long id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public IQueryable<TEntity> FindAll() => Context.Set<TEntity>().AsNoTracking();
        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression) =>
            Context.Set<TEntity>().Where(expression).AsNoTracking();
        public IQueryable<TEntity> Include(Expression<Func<TEntity, object>> expression) =>
             Context.Set<TEntity>().Include(expression).AsNoTracking();
        public void Create(TEntity entity) => Context.Set<TEntity>().Add(entity);
        public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);
        public void UpdateRange(IEnumerable<TEntity> entities) => Context.Set<TEntity>().UpdateRange(entities);
        public void Delete(TEntity entity) => Context.Set<TEntity>().Remove(entity);

    }
}

