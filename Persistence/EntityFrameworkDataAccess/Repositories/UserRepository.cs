using Application.Interfaces;
using Application.Security.Repositories;
using Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.EntityFrameworkDataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MoisContext _dbContext;

        public UserRepository(MoisContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public async Task AddUserAsync(User user, ERole[] userRoles)
        {
            var roles = await _dbContext.Roles.Where(r => userRoles.Any(ur => ur.ToString() == r.Name))
                                            .ToListAsync();

            foreach (var role in roles)
            {
                user.UserRoles.Add(new UserRole { RoleId = role.Id });
            }

            _dbContext.Users.Add(user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _dbContext.Users.Include(u => u.UserRoles)
                                       .ThenInclude(ur => ur.Role)
                                       .SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
