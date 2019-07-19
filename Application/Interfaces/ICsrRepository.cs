using Domain.Entities.Documents;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICsrRepository : IBaseRepository
    {
        Task CreateCsr(CriminalStateRecord csr);
        int GetDefaultNumberOfCopies();
    }
}
