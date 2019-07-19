using Domain.Entities.Documents;
using System.Threading.Tasks;
using Application.Services.Communication;

namespace Application.Interfaces
{
    public interface ICsrService
    {
        Task<CsrResponse> CreateCsrAsync(CriminalStateRecord csr);
    }
}
