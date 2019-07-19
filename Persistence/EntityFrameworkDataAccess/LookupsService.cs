using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFrameworkDataAccess
{
    public class LookupsService : ILookupsService
    {
        protected readonly MoisContext _dbContext;        
        public LookupsService(MoisContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<T>> GetLookups<T>() where T : class => await _dbContext.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T> Find<T>(object keyValue) where T : class => await _dbContext.Set<T>().FindAsync(keyValue);
        public async Task<T> Find<T>(params object[] keyValues) where T : class => await _dbContext.Set<T>().FindAsync(keyValues);
        public async Task<T> FindWhere<T>(Expression<Func<T, bool>> predicate) where T : class => await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<T>> GetLookups<T>(Expression<Func<T, bool>> predicate = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            /*Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null,*/
            string includeProperties = null,
           bool disableTracking = true
           ) where T : class
        {
            //_logger.LogWarning("GetLookups");
            IQueryable<T> query = _dbContext.Set<T>();

            if (disableTracking)
                query = query.AsNoTracking();

            //if (includes != null)
            //    query = includes(query);
            foreach (string prop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(prop);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TResult>> GetLookupsProjected<T, TResult>(Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            /*Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null,*/
            string includeProperties = null,
            bool disableTracking = true
            ) where T : class
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (disableTracking)
                query = query.AsNoTracking();

            //if (includes != null)
            //    query = includes(query);
            foreach (string prop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(prop);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            return await query.Select(selector).ToListAsync();
        }
    }
}
