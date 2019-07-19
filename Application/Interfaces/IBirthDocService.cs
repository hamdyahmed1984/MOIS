using Domain.Entities.Documents;
using System.Threading.Tasks;
using Application.Services.Communication;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IBirthDocService: IDocService
    {
        Task<IEnumerable<BirthDocResponse>> CreateBirthDocsAsync(IEnumerable<BirthDoc> birthDocs, bool autoSave = false);
    }
}
