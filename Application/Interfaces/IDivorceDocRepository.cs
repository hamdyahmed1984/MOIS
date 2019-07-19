using Domain.Entities.Documents;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDivorceDocRepository : IBaseRepository
    {
        Task CreateDivorceDoc(DivorceDoc divorceDoc);
    }
}
