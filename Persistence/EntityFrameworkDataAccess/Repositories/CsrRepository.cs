
using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFrameworkDataAccess.Repositories
{
    public class CsrRepository : BaseRepository, ICsrRepository
    {
        public CsrRepository(MoisContext dbContext): base(dbContext) { }

        public async Task CreateCsr(CriminalStateRecord csr)
        {
            await _dbContext.CriminalStateRecords.AddAsync(csr);
        }

        public int GetDefaultNumberOfCopies() => 1;
    }
}
