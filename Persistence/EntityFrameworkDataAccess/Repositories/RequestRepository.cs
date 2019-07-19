using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFrameworkDataAccess.Repositories
{
    public class RequestRepository: BaseRepository, IRequestRepository
    {
        public RequestRepository(MoisContext dbContext): base(dbContext) { }

        public async Task CreateRequest(Request request)
        {
            await _dbContext.Requests.AddAsync(request);
        }

        public async Task<Request> GetRequest(int requestId)
        {
            return await _dbContext.Requests
                .Include(a => a.RequestStates).ThenInclude(a => a.State)
                .Include(a => a.BirthDocs).ThenInclude(b => b.State)
                .Include(a => a.DeathDocs).ThenInclude(b => b.State)
                .Include(a => a.DivorceDocs).ThenInclude(b => b.State)
                .Include(a => a.FamilyRecords).ThenInclude(b => b.State)
                .Include(a => a.MarriageDocs).ThenInclude(b => b.State)
                .Include(a => a.NidDoc).ThenInclude(b => b.State)
                .Include(a => a.PersonalRecords).ThenInclude(b => b.State)
                .Include(a => a.CriminalStateRecords).ThenInclude(b => b.State)
                .Include(a => a.WorkPermitClearances).ThenInclude(b => b.State)
                .Include(a => a.WorkPermitRenews).ThenInclude(b => b.State)
                .Include(a => a.WorkPermitReplaces).ThenInclude(b => b.State)
                .FirstOrDefaultAsync(a => a.Id == requestId);
        }
    }
}
