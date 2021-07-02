using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Infrastructure.Data;
using Core.Interfaces;
namespace Infrastructure.Repository
{
    public class RepositoryApp<T> : IRepositoryApp<T> where T : class
    {
        private readonly AppDbContext _db;
        private DbSet<T> Entity = null;

        public RepositoryApp(AppDbContext db)
        {
            _db = db;
            Entity = _db.Set<T>();
        }
        #region main operation
        public void Add(T entity)
        {
            Entity.Add(entity);
        }
        public void Update(T entity)
        {
           var x= Entity.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            Entity.Remove(entity);
        }

        public void DeleteRange(params T[] entities)
        {
            Entity.RemoveRange(entities);
        }
        
        #endregion

        #region GetALL Async =>(IQueryable)
        public IQueryable<T> GetAll()
        {
            return Entity;
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var result = Entity.Where(i => true);

            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);

            return result;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            return Entity.Where(whereCondition);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes)
        {
            var result = Entity.Where(whereCondition);
            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);
            return result;
        }

        #endregion

        #region GetALL Async =>(IEnumerable)

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entity.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var result = Entity.Where(i => true);
            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);
            return await result.ToListAsync(); ;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereCondition)
        {
             return await Entity.Where(whereCondition).ToListAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes)
        {
            var result = Entity.Where(whereCondition);
            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);
            return await result.ToListAsync();
        }

        #endregion

        #region GetById Async  

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Entity.FindAsync(id);
            
        }
        


        #endregion

        #region  SingleOrDefaultAsync
        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> whereCondition)
        {
            return await Entity.Where(whereCondition).FirstOrDefaultAsync();
        }
        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> whereCondition, params Expression<Func<T, object>>[] includes)
        {
            var result =Entity.Where(whereCondition);
            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);

            return await result.FirstOrDefaultAsync();
        }
        #endregion

        #region OrderBy
        public IEnumerable<T> OrderBy(Expression<Func<T, bool>> whereCondition)
        {
            return Entity.OrderBy(whereCondition);
        }
        public IEnumerable<T> OrderByDescending(Expression<Func<T, bool>> whereCondition)
        {
            return Entity.OrderByDescending(whereCondition);
        }
        #endregion
 

        #region SaveAllAsync
        public async Task<bool> SaveAllAsync()
        {


            return await _db.SaveChangesAsync() > 0;
             
        }


        #endregion
        #region checkState
        public bool checkState(T entity, string state )
        {
            var x = _db.Entry(entity).State;
           return ( _db.Entry(entity).State.ToString().ToLower() == state.ToLower().Trim()) ? true : false;
        }

        public DbSet<T> GetContext()
        {
            return Entity;

        }

        public async Task<T> FirstAsync()
        {
            return await Entity.FirstOrDefaultAsync();
        }
        #endregion


    }
}