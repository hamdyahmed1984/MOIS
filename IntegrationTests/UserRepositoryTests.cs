using Domain.Entities;
using Domain.Entities.Documents;
using Domain.Entities.Security;
using Persistence.EntityFrameworkDataAccess;
using Persistence.EntityFrameworkDataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests
{
    public class UserRepositoryTests : BaseEfRepositoryTestFixture
    {
        private readonly MoisContext _moisContext;
        private readonly UserRepository _userRepository;

        //The constructor is called with every test method
        public UserRepositoryTests()
        {
            _moisContext = new MoisContext(CreateNewContextOptions());
            _userRepository = new UserRepository(_moisContext);            
            PrepareData();
        }

        private void PrepareData()
        {
            if (_moisContext.Roles.Any())
            {
                _moisContext.Roles.ToList().ForEach(a => _moisContext.Roles.Remove(a));
            }
            _moisContext.Roles.AddRange(new List<Role>()
            {
                new Role(){ Name = "Common" },
                new Role(){ Name = "Administrator" }
            });
            _moisContext.SaveChanges();
        }

        [Fact]
        public async Task AddUserWithRolesAndCheckForRoles()
        {
            var user = new User() { Email = "a@a.a", Password = "123456" };
            var roles = new ERole[] { ERole.Common, ERole.Administrator };

            await _userRepository.AddUserAsync(user, roles);
            await _userRepository.UnitOfWork.CommitChangesAsync();

            Assert.True(user.Id > 0);

            var userFromDB = _moisContext.Users.FirstOrDefault(a => a.Id == user.Id);
            Assert.Equal(user.Email, userFromDB.Email);
            Assert.Equal(2, userFromDB.UserRoles.Count);            
        }

        [Fact]
        public async Task FindByEmailTest()
        {
            var user = new User() { Email = "a@a.a", Password = "123456" };
            var roles = new ERole[] { ERole.Common, ERole.Administrator };

            await _userRepository.AddUserAsync(user, roles);
            await _userRepository.UnitOfWork.CommitChangesAsync();

            var userFromDB = await _userRepository.FindByEmailAsync("a@a.a");
            Assert.Equal(user.Email, userFromDB.Email);
            Assert.Equal(2, userFromDB.UserRoles.Count);
        }
    }
}
