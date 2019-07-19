using Domain.Entities.Documents;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBirthDocRepository : IBaseRepository
    {
        Task CreateBirthDoc(BirthDoc birthDoc);
    }
}
