using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICachedLookupsService : ILookupsService { }//This interface is created just to prevent circular dependency exception of ILookupsService
    public interface ILookupsService
    {
        Task<IEnumerable<T>> GetLookups<T>() where T : class;
        Task<IEnumerable<T>> GetLookups<T>(string includeProperties) where T : class;
        Task<T> Find<T>(object keyValue) where T : class;
        Task<T> Find<T>(params object[] keyValues) where T : class;
        Task<T> FindWhere<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<IEnumerable<T>> GetLookups<T>(Expression<Func<T, bool>> predicate = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            /*Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null,*/
            string includeProperties = null,
           bool disableTracking = true
           ) where T : class;
        Task<IEnumerable<TResult>> GetLookupsProjected<T, TResult>(Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            /*Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null,*/
            string includeProperties = null,
            bool disableTracking = true
            ) where T : class;
    }
}
