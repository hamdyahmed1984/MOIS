using Application.Interfaces;
using Application.Interfaces.PagedList;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFrameworkDataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.EntityFrameworkDataAccess
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MoisContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public EfRepository(MoisContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }

        public IUnitOfWork UnitOfWork => _dbContext;
        
        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate = null,
                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                string includeProperties = null,
                                                int pageIndex = 0,
                                                int pageSize = 20,
                                                bool disableTracking = true)
        {
            IQueryable<TEntity> query = ApplyOptionsToQuery(predicate, orderBy, includeProperties, disableTracking);
            return query.ToPagedList(pageIndex, pageSize);
        }

        private IQueryable<TEntity> ApplyOptionsToQuery(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties, bool disableTracking)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            foreach (string prop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(prop);

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
                query = orderBy(query);
            return query;
        }

        public virtual Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                           string includeProperties = null,
                                                           int pageIndex = 0,
                                                           int pageSize = 20,
                                                           bool disableTracking = true,
                                                           CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<TEntity> query = ApplyOptionsToQuery(predicate, orderBy, includeProperties, disableTracking);
            return query.ToPagedListAsync(pageIndex, pageSize, 0, cancellationToken);
        }
        public virtual IPagedList<TResult> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                         Expression<Func<TEntity, bool>> predicate = null,
                                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                         string includeProperties = null,
                                                         int pageIndex = 0,
                                                         int pageSize = 20,
                                                         bool disableTracking = true)
            where TResult : class
        {
            IQueryable<TEntity> query = ApplyOptionsToQuery(predicate, orderBy, includeProperties, disableTracking);
            return query.Select(selector).ToPagedList(pageIndex, pageSize);
        }
        public virtual Task<IPagedList<TResult>> GetPagedListAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                                    Expression<Func<TEntity, bool>> predicate = null,
                                                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                    string includeProperties = null,
                                                                    int pageIndex = 0,
                                                                    int pageSize = 20,
                                                                    bool disableTracking = true,
                                                                    CancellationToken cancellationToken = default(CancellationToken))
            where TResult : class
        {
            IQueryable<TEntity> query = ApplyOptionsToQuery(predicate, orderBy, includeProperties, disableTracking);
            return query.Select(selector).ToPagedListAsync(pageIndex, pageSize, 0, cancellationToken);
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                         string includeProperties = null,
                                         bool disableTracking = true)
        {
            IQueryable<TEntity> query = ApplyOptionsToQuery(predicate, orderBy, includeProperties, disableTracking);
            return query.FirstOrDefault();
        }


        /// <inheritdoc />
        public virtual async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = ApplyOptionsToQuery(predicate, orderBy, includeProperties, disableTracking);
            return await query.FirstOrDefaultAsync();
        }
        public virtual TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                  Expression<Func<TEntity, bool>> predicate = null,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                  string includeProperties = null,
                                                  bool disableTracking = true)
        {
            IQueryable<TEntity> query = ApplyOptionsToQuery(predicate, orderBy, includeProperties, disableTracking);
            return query.Select(selector).FirstOrDefault();
        }

        /// <inheritdoc />
        public virtual async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                  Expression<Func<TEntity, bool>> predicate = null,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                  string includeProperties = null,
                                                  bool disableTracking = true)
        {
            IQueryable<TEntity> query = ApplyOptionsToQuery(predicate, orderBy, includeProperties, disableTracking);
            return await query.Select(selector).FirstOrDefaultAsync();
        }

        public virtual IQueryable<TEntity> FromSql(string sql, params object[] parameters) => _dbSet.FromSql(sql, parameters);

        public virtual TEntity Find(params object[] keyValues) => _dbSet.Find(keyValues);

        public virtual Task<TEntity> FindAsync(params object[] keyValues) => _dbSet.FindAsync(keyValues);

        public virtual Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken) => _dbSet.FindAsync(keyValues, cancellationToken);

        /// <returns></returns>
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null) => predicate == null ? await _dbSet.CountAsync() : await _dbSet.CountAsync(predicate);
        
        public virtual void Insert(TEntity entity)=> _dbSet.Add(entity);

        public virtual void Insert(params TEntity[] entities) => _dbSet.AddRange(entities);

        public virtual void Insert(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);

        public virtual Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken)) => _dbSet.AddAsync(entity, cancellationToken);

        public virtual Task InsertAsync(params TEntity[] entities) => _dbSet.AddRangeAsync(entities);

        public virtual Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken)) => _dbSet.AddRangeAsync(entities, cancellationToken);

        public virtual void Update(TEntity entity) => _dbSet.Update(entity);

        public virtual void UpdateAsync(TEntity entity) => Update(entity);
  
        public virtual void Update(params TEntity[] entities) => _dbSet.UpdateRange(entities);

        public virtual void Update(IEnumerable<TEntity> entities) => _dbSet.UpdateRange(entities);

        public virtual void Delete(TEntity entity) => _dbSet.Remove(entity);

        public virtual async Task DeleteAsync(object id)
        {
            // using a stub entity to mark for deletion
            var typeInfo = typeof(TEntity).GetTypeInfo();
            var key = _dbContext.Model.FindEntityType(typeInfo).FindPrimaryKey().Properties.FirstOrDefault();
            var property = typeInfo.GetProperty(key?.Name);
            if (property != null)
            {
                var entity = Activator.CreateInstance<TEntity>();
                property.SetValue(entity, id);
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            else
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    Delete(entity);
                }
            }
        }

        public virtual void Delete(params TEntity[] entities) => _dbSet.RemoveRange(entities);

        public virtual void Delete(IEnumerable<TEntity> entities) => _dbSet.RemoveRange(entities);








        //public virtual async Task<T> Add(T entity)
        //{
        //    _dbContext.Set<T>().Add(entity);
        //    await _dbContext.SaveChangesAsync();
        //    return entity;
        //}

        //public virtual async Task Update(T entity)
        //{
        //    _dbContext.Entry(entity).State = EntityState.Modified;
        //    await _dbContext.SaveChangesAsync();
        //}

        //public virtual async Task Delete(T entity)
        //{
        //    _dbContext.Set<T>().Remove(entity);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public virtual async Task Delete(object id)
        //{
        //    var entity = await _dbContext.Set<T>().FindAsync(id);
        //    await Delete(entity);
        //}

        //public virtual async Task<T> Get(Expression<Func<T, bool>> where)
        //{
        //    return await _dbContext.Set<T>().FirstOrDefaultAsync(where);
        //}

        //public virtual async Task<List<T>> Get(Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties)
        //{
        //    IQueryable<T> query = _dbContext.Set<T>();

        //    if (where != null)
        //        query = query.Where(where);

        //    foreach (string prop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        query.Include(prop);

        //    return orderBy == null ? await query.ToListAsync() : await orderBy(query).ToListAsync();
        //}

        //public virtual async Task<List<T>> GetAll()
        //{
        //    return await _dbContext.Set<T>().ToListAsync();
        //}

        //public virtual async Task<T> GetById(object id)
        //{
        //    return await _dbContext.Set<T>().FindAsync(id);
        //}

        //public virtual async Task<List<T>> GetMany(Expression<Func<T, bool>> where)
        //{
        //    return await _dbContext.Set<T>().Where(where).ToListAsync();
        //}
    }
}
