
using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFrameworkDataAccess.Repositories
{
    public class MarriageDocRepository : BaseRepository, IMarriageDocRepository
    {
        public MarriageDocRepository(MoisContext dbContext): base(dbContext) { }

        public async Task CreateMarriageDoc(MarriageDoc marriageDoc)
        {
            await _dbContext.MarriageDocs.AddAsync(marriageDoc);
        }
    }
}
