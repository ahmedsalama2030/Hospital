using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces
{
    public interface IRepositoryApp<T> where T : class
    {
        #region main operation
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(params T[] entities);

        #endregion

        #region GetById Async
        Task<T> GetByIdAsync(Guid id);

        #endregion

        #region GetALL Async =>(IEnumerable)
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereCondition);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes);
        #endregion

        #region  GetALL Async =>(IQueryable)
        IQueryable<T> GetAll();

        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);

        IQueryable<T> GetAll(Expression<System.Func<T, bool>> whereCondition);

        IQueryable<T> GetAll(Expression<System.Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes);

        #endregion

        #region SingleOrDefault Async
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> whereCondition);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes);

        #endregion

        #region OrderBy
        IEnumerable<T> OrderBy(Expression<Func<T, bool>> whereCondition);
        IEnumerable<T> OrderByDescending(Expression<Func<T, bool>> whereCondition);
        #endregion

        #region SaveAllAsync
        Task<bool> SaveAllAsync();

        #endregion

        #region checkState
        public bool checkState(T entity,string state);
        public DbSet<T> GetContext();

        #endregion
        #region Get first
        Task<T> FirstAsync();


        #endregion
    }
}