using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFrameworkDataAccess.Repositories
{
    public abstract class BaseRepository: IBaseRepository
    {
        protected readonly MoisContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public BaseRepository(MoisContext dbContext)
        {
            _dbContext = dbContext;
        }        
    }
}
