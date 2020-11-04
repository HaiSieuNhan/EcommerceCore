using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Domain;
using Ecommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Ecommerce.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly EcommerceDbContext DbContext;


        public BaseRepository(EcommerceDbContext dbContext)
        {
            DbContext = dbContext;

        }

        #region Async function       

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }
        public virtual async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult<IQueryable<T>>(DbContext.Set<T>());
        }

        public virtual async Task<T> AddAsync(T entity, bool isSaved = true)
        {
            await DbContext.Set<T>().AddAsync(entity);
            if (isSaved)
            {
                await DbContext.SaveChangesAsync();
            }
            return entity;
        }

        public virtual async Task<bool> AddManyAsync(IEnumerable<T> entities)
        {
            await DbContext.Set<T>().AddRangeAsync(entities);
            await DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await DbContext.Set<T>().Where(match).ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await DbContext.Set<T>().SingleOrDefaultAsync(match);
        }

        public T GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            try
            {
                IQueryable<T> query = DbContext.Set<T>().AsNoTracking();

                if (include != null) query = include(query);

                query = query.Where(predicate);

                if (orderBy != null) query = orderBy(query);

                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateRangeAsync(List<T> entities)
        {
            DbContext.Set<T>().UpdateRange(entities);

            await DbContext.SaveChangesAsync();


        }

        public async Task DeleteRangeAsync(List<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
            await DbContext.SaveChangesAsync();
        }


        #endregion

        #region Normal function

        public virtual T GetById(Guid id)
        {
            return DbContext.Set<T>().Find(id);

        }
        public virtual T Add(T entity, bool isSave = true)
        {
            DbContext.Set<T>().Add(entity);
            if (isSave)
            {
                DbContext.SaveChanges();
            }


            return entity;
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public virtual void Update(T entity, bool isSave = true)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            if (isSave)
            {
                DbContext.SaveChanges();
            }

        }
        public virtual void Delete(T entity, bool isSave = true)
        {
            DbContext.Set<T>().Remove(entity);
            if (isSave)
            {
                DbContext.SaveChanges();
            }

        }

        public virtual bool AddMany(IEnumerable<T> entities)
        {
            DbContext.Set<T>().AddRange(entities);
            DbContext.SaveChanges();

            return true;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = DbContext.Set<T>().Where(predicate);
            return query;
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return DbContext.Set<T>().SingleOrDefault(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return DbContext.Set<T>().Where(match).ToList();
        }

        public T Get(Guid id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }

        public virtual async Task UpdateAsync(T entity, bool isSave = true)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            if (isSave)
            {
                await DbContext.SaveChangesAsync();
            }

        }


        public virtual async Task DeleteAsync(T entity, bool isSave = true)
        {
            DbContext.Set<T>().Remove(entity);
            if (isSave)
            {
                await DbContext.SaveChangesAsync();
            }

        }
        public virtual async Task SaveChangesAsync(bool isSave)
        {
            if (isSave)
            {
                await DbContext.SaveChangesAsync();
            }
        }
        public T GetSingleOrDefault(Expression<Func<T, bool>> match)
        {
            throw new NotImplementedException();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(List<T> entities)
        {
            DbContext.Set<T>().UpdateRange(entities);
            DbContext.SaveChanges();
        }

        public void DeleteRange(List<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
            DbContext.SaveChangesAsync();
        }

        




        #endregion


    }
}
