using Domain.Entities;
using Domain.Entities.Lookups;
using Domain.Entities.Documents;
using Domain.ValueObjects;
using System.Threading.Tasks;
using Application.Services.Communication;

namespace Application.Interfaces
{
    public interface IRequestService
    {
        Task<RequestResponse> CreateRequestAsync(Request request, string issuerCode, bool previewOnly = false);
        Task<RequestResponse> GetRequestAsync(int requestId);
    }
}
