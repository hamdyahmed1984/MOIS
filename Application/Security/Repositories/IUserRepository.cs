using Application.Interfaces;
using Domain.Entities.Security;
using System.Threading.Tasks;

namespace Application.Security.Repositories
{
    public interface IUserRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Task AddUserAsync(User user, ERole[] userRoles);
        Task<User> FindByEmailAsync(string email);
    }
}
