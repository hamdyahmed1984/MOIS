using Domain.Entities.Documents;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDeathDocRepository : IBaseRepository
    {
        Task CreateDeathDoc(DeathDoc deathRecord);
    }
}
