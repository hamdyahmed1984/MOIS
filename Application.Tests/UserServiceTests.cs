using Xunit;
using System.Threading.Tasks;
using Moq;
using Application.Interfaces;
using Application.Security.Hashing;
using Application.Security.Services;
using Domain.Entities.Security;
using Application.Security.Services.Communication;
using Application.Security.Repositories;
using System.Linq;

namespace Application.Tests
{
    public class UserServiceTests
    {
        Mock<IUserRepository> mockUserRepo;
        Mock<IPasswordHasher> mockPasswordHasher;

        [Fact]
        public async Task CreateUserAsync_ReturnsFailedCreateUserResponse_WhenUseAlreadyExists()
        {
            //Arrange
            CreateMockedObjects();
            mockUserRepo.Setup(a => a.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(new User());
            UserService userService = new UserService(mockUserRepo.Object, mockPasswordHasher.Object);
            User user = new User() { Email = "a@a.a" };
            ERole[] roles = new ERole[] { ERole.Common }; 

            //Act
            var result = await userService.CreateUserAsync(user, roles);

            //Assert
            Assert.IsAssignableFrom<CreateUserResponse>(result);
            Assert.False(result.Success);
            Assert.Null(result.User);
        }

        [Fact]
        public async Task CreateUserAsync_ReturnsSucceededCreateUserResponse_WhenCreatingUser()
        {
            //Arrange
            CreateMockedObjects();
            mockUserRepo.Setup(a => a.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync((User)null);
            mockPasswordHasher.Setup(a => a.HashPassword(It.IsAny<string>())).Returns("test");
            mockUserRepo.Setup(a => a.AddUserAsync(It.IsAny<User>(), It.IsAny<ERole[]>()));
            mockUserRepo.SetupGet(a => a.UnitOfWork).Returns(new FakeUnitOfWork());
            UserService userService = new UserService(mockUserRepo.Object, mockPasswordHasher.Object);
            User user = new User() { Email = "a@a.a" };
            ERole[] roles = new ERole[] { ERole.Common };

            //Act
            var result = await userService.CreateUserAsync(user, roles);

            //Assert
            Assert.IsAssignableFrom<CreateUserResponse>(result);
            Assert.True(result.Success);
            Assert.NotNull(result.User);
        }

        private void CreateMockedObjects()
        {
            mockUserRepo = new Mock<IUserRepository>();
            mockPasswordHasher = new Mock<IPasswordHasher>();
        }
    }
    internal class FakeUnitOfWork : IUnitOfWork
    {
        public int CommitChanges() => 0;
        public Task<int> CommitChangesAsync() => Task.FromResult(0);
        public void Dispose() { }
        public int ExecuteSqlCommand(string sql, params object[] parameters) => 0;
        public IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class => null;
    }
}
