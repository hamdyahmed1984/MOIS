using Domain.Entities.Documents;
using System.Threading.Tasks;
using Application.Services.Communication;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IDeathDocService : IDocService
    {
        Task<IEnumerable<DeathDocResponse>> CreateDeathDocsAsync(IEnumerable<DeathDoc> deathRecords, bool autoSave = false);
    }
}
