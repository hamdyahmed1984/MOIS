using Application.Interfaces.PagedList;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<TEntity>// where T : Domain.Entities.BaseEntity
    {
        IUnitOfWork UnitOfWork { get; }
        IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                         string includeProperties = null,
                                         int pageIndex = 0,
                                         int pageSize = 20,
                                         bool disableTracking = true);
        Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate = null,
                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                            string includeProperties = null,
                                            int pageIndex = 0,
                                            int pageSize = 20,
                                            bool disableTracking = true,
                                            CancellationToken cancellationToken = default(CancellationToken));
        IPagedList<TResult> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                  Expression<Func<TEntity, bool>> predicate = null,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                   string includeProperties = null,
                                                  int pageIndex = 0,
                                                  int pageSize = 20,
                                                  bool disableTracking = true) where TResult : class;

        Task<IPagedList<TResult>> GetPagedListAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                             Expression<Func<TEntity, bool>> predicate = null,
                                                             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                              string includeProperties = null,
                                                             int pageIndex = 0,
                                                             int pageSize = 20,
                                                             bool disableTracking = true,
                                                             CancellationToken cancellationToken = default(CancellationToken)) where TResult : class;
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                   string includeProperties = null,
                                  bool disableTracking = true);
        TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
                                           Expression<Func<TEntity, bool>> predicate = null,
                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                            string includeProperties = null,
                                           bool disableTracking = true);

        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
             string includeProperties = null,
            bool disableTracking = true);


        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
             string includeProperties = null,
            bool disableTracking = true);

        IQueryable<TEntity> FromSql(string sql, params object[] parameters);
        TEntity Find(params object[] keyValues);
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken);
        
        IQueryable<TEntity> GetAll();

        Task<IList<TEntity>> GetAllAsync();
        
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);
        
        void Insert(TEntity entity);
        
        void Insert(params TEntity[] entities);
        
        void Insert(IEnumerable<TEntity> entities);
        
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        
        Task InsertAsync(params TEntity[] entities);
        
        Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
        
        void Update(TEntity entity);
        
        void Update(params TEntity[] entities);
        
        void Update(IEnumerable<TEntity> entities);
        
        Task DeleteAsync(object id);
        
        void Delete(TEntity entity);
        
        void Delete(params TEntity[] entities);
        
        void Delete(IEnumerable<TEntity> entities);

        //Task<T> Add(T entity);
        //Task Update(T entity);
        //Task Delete(T entity);
        //Task Delete(object id);
        //Task<T> GetById(object id);
        //Task<T> Get(Expression<Func<T, bool>> where);
        //Task<List<T>> GetAll();
        //Task<List<T>> GetMany(Expression<Func<T, bool>> where);
        //Task<List<T>> Get(Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties);
    }
}
