
using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFrameworkDataAccess.Repositories
{
    public class NidDocRepository : BaseRepository, INidDocRepository
    {
        public NidDocRepository(MoisContext dbContext): base(dbContext) { }

        public async Task CreateNidDoc(NidDoc nationalIdenNumber)
        {
            await _dbContext.NidDocs.AddAsync(nationalIdenNumber);
        }
    }
}
