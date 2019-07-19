using Domain.Entities.Documents;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INidDocRepository : IBaseRepository
    {
        Task CreateNidDoc(NidDoc nationalIdenNumber);
    }
}
