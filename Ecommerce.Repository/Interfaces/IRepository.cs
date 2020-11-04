using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        #region Normal Function
        T GetById(Guid Id);
        IQueryable<T> GetAll();
        T Find(Expression<Func<T, bool>> match);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        T GetFirstOrDefault(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
                                 IOrderedQueryable<T>> orderBy = null,
                                 Func<IQueryable<T>, IIncludableQueryable<T, Object>> include = null);
        T Add(T entity, bool isSave);
        bool AddMany(IEnumerable<T> entities);
        void Update(T entity, bool isSave);
        void UpdateRange(List<T> entity);
        void Delete(T entity, bool isSave);
        void DeleteRange(List<T> entity);
        

        #endregion
        #region Async Function
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        Task<T> GetByIdAsync(Guid id);
        Task<IQueryable<T>> GetAllAsync();

        T GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
                                 IOrderedQueryable<T>> orderBy = null,
                                 Func<IQueryable<T>, IIncludableQueryable<T, Object>> include = null);

        Task<T> AddAsync(T entity, bool isSave);
        
        Task<bool> AddManyAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity, bool isSave);
        Task UpdateRangeAsync(List<T> entity);
        Task DeleteAsync(T entity, bool isSave);
        Task DeleteRangeAsync(List<T> entity);
        Task SaveChangesAsync(bool isSave);
        #endregion
    }
}
