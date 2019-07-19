using Domain.Entities.Documents;
using System.Threading.Tasks;
using Application.Services.Communication;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IDivorceDocService : IDocService
    {
        Task<IEnumerable<DivorceDocResponse>> CreateDivorceDocsAsync(IEnumerable<DivorceDoc> divorceDocs, bool autoSave = false);
    }
}
