using Application.Security.Services.Communication;
using Domain.Entities.Security;
using System.Threading.Tasks;

namespace Application.Security.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUserAsync(User user, params ERole[] userRoles);
        Task<User> FindByEmailAsync(string email);
    }
}
