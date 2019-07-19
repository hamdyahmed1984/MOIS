using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDocService
    {
        Task<decimal> GetDocPrice();
    }
}
