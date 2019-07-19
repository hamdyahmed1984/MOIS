using Domain.Entities.Documents;
using System.Threading.Tasks;
using Application.Services.Communication;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface INidDocService : IDocService
    {
        Task<NidDocResponse> CreateNidDocAsync(NidDoc nationalIdenNumber, bool autoSave = false);
    }
}
