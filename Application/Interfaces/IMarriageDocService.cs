using Domain.Entities.Documents;
using System.Threading.Tasks;
using Application.Services.Communication;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IMarriageDocService: IDocService
    {
        Task<IEnumerable<MarriageDocResponse>> CreateMarriageDocsAsync(IEnumerable<MarriageDoc> marriageDocs, bool autoSave = false);
    }
}
