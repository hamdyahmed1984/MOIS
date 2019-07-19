//using Application.Interfaces;
//using Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace Persistence.EntityFrameworkDataAccess.Repositories
//{
//    public class LookupsRepository<TEntity>: ILookupsRepository<TEntity> where TEntity: LookupBase
//    {
//        protected readonly MoisContext _dbContext;
//        protected readonly DbSet<TEntity> _dbSet;
//        public LookupsRepository(MoisContext dbContext)
//        {
//            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
//            _dbSet = _dbContext.Set<TEntity>();
//        }

//        public async Task<TEntity> Find(object key) => await _dbSet.FindAsync(key);

//        public async Task<TEntity> FindByCode(string code) => await _dbSet.FirstOrDefaultAsync(a => a.Code == code);

//        public async Task<IEnumerable<TEntity>> GetLookups()=> await _dbSet.ToListAsync();
//    }
//}
