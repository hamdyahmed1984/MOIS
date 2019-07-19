
using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFrameworkDataAccess.Repositories
{
    public class DeathDocRepository : BaseRepository, IDeathDocRepository
    {
        public DeathDocRepository(MoisContext dbContext): base(dbContext) { }

        public async Task CreateDeathDoc(DeathDoc deathDoc)
        {
            await _dbContext.DeathDocs.AddAsync(deathDoc);
        }
    }
}
