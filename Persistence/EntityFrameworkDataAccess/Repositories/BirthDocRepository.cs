
using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFrameworkDataAccess.Repositories
{
    public class BirthDocRepository : BaseRepository, IBirthDocRepository
    {
        public BirthDocRepository(MoisContext dbContext): base(dbContext) { }

        public async Task CreateBirthDoc(BirthDoc birthDoc)
        {
            await _dbContext.BirthDocs.AddAsync(birthDoc);
        }
    }
}
