using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRequestRepository: IBaseRepository
    {
        Task CreateRequest(Request request);
        Task<Request> GetRequest(int requestId);
    }
}
