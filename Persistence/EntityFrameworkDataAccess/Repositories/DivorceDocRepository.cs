
using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFrameworkDataAccess.Repositories
{
    public class DivorceDocRepository : BaseRepository, IDivorceDocRepository
    {
        public DivorceDocRepository(MoisContext dbContext): base(dbContext) { }

        public async Task CreateDivorceDoc(DivorceDoc divorceDoc)
        {
            await _dbContext.DivorceDocs.AddAsync(divorceDoc);
        }
    }
}
