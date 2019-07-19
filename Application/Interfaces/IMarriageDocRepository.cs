using Domain.Entities.Documents;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMarriageDocRepository : IBaseRepository
    {
        Task CreateMarriageDoc(MarriageDoc marriageDoc);
    }
}
