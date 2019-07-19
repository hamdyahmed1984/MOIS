using Xunit;
using Application.Security.Hashing;

namespace Application.Tests
{
    public class PasswordHasherTests
    {
        [Fact]
        public void PasswordMatches_ShouldReturnTrueWhenThe2HashesAreForTheSamePassword()
        {
            //Arrange
            PasswordHasher passwordHasher = new PasswordHasher();
            string password = "123456";

            //Act
            var passwordHash = passwordHasher.HashPassword(password);
            var isMatching = passwordHasher.PasswordMatches(password, passwordHash);

            //Assert
            Assert.True(isMatching);
        }
    }
}
