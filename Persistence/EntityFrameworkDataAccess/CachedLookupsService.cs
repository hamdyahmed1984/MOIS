using Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence.EntityFrameworkDataAccess
{
    public class CachedLookupsService : ICachedLookupsService
    {
        private readonly ILookupsService _lookupsService;
        private readonly IMemoryCache _memoryCache;
        private const string _cacheKey = "Lookups.";
        public CachedLookupsService(ILookupsService lookupsService, IMemoryCache memoryCache)
        {
            _lookupsService = lookupsService;
            _memoryCache = memoryCache;
        }
        public async Task<T> Find<T>(object keyValue) where T : class
        {
            string cachekey = _cacheKey + typeof(T).Name + $".{keyValue}";
            return await _memoryCache.GetOrCreateAsync<T>(cachekey, async entry =>
            {
                return await _lookupsService.Find<T>(keyValue);
            });
        }

        public async Task<T> Find<T>(params object[] keyValues) where T : class
        {
            string cachekey = _cacheKey + typeof(T).Name + $".{string.Join("_", keyValues)}";
            return await _memoryCache.GetOrCreateAsync<T>(cachekey, async entry =>
            {
                return await _lookupsService.Find<T>(keyValues);
            });
        }

        public async Task<IEnumerable<T>> GetLookups<T>() where T : class
        {
            string cachekey = _cacheKey + typeof(T).Name + $".All";
            return await _memoryCache.GetOrCreateAsync<IEnumerable<T>>(cachekey, async entry =>
            {
                return await _lookupsService.GetLookups<T>();
            });
        }

        public async Task<IEnumerable<T>> GetLookups<T>(string includeProperties) where T : class
        {
            string cachekey = _cacheKey + typeof(T).Name + $".All_" + includeProperties.Replace(",", "_").Replace(" ", "_");
            return await _memoryCache.GetOrCreateAsync<IEnumerable<T>>(cachekey, async entry =>
            {
                return await _lookupsService.GetLookups<T>(includeProperties);
            });
        }

        public async Task<T> FindWhere<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            ////In case we get the data from DB: No caching here as we cann't parse the lambda expression with parameters and values
            //return await _lookupsService.FindWhere<T>(predicate);

            //But in case we get the data from the cashed data there is already a caching we can make use of
            var allCachedLookups = await this.GetLookups<T>();
            return allCachedLookups.FirstOrDefault<T>(predicate.Compile());
        }

        public async Task<IEnumerable<T>> GetLookups<T>(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, bool disableTracking = true) where T : class
        {
            //No caching here as we cann't parse the lambda expression with parameters and values
            return await _lookupsService.GetLookups<T>(predicate, orderBy, includeProperties, disableTracking);
        }

        public async Task<IEnumerable<TResult>> GetLookupsProjected<T, TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, bool disableTracking = true) where T : class
        {
            //No caching here as we cann't parse the lambda expression with parameters and values
            return await _lookupsService.GetLookupsProjected<T, TResult>(selector, predicate, orderBy, includeProperties, disableTracking);
        }
    }
}
