using Xunit;
using System;
using Application.Security.Tokens;
using Moq;
using Application.Security.Hashing;
using Microsoft.Extensions.Options;
using Application.Configs;
using Domain.Entities.Security;
using System.Collections.Generic;

namespace Application.Tests
{
    public class TokenHandlerTests
    {
        private Mock<IPasswordHasher> mockPasswordHasher;

        [Fact]
        public void CreateAccessToken_ReturnsAccessToken_WhenTokenCreated()
        {
            //Arrange
            mockPasswordHasher = new Mock<IPasswordHasher>();
            mockPasswordHasher.Setup(a => a.HashPassword(It.IsAny<string>())).Returns("test");
            TokenHandler tokenHandler = new TokenHandler(GetFakeConfigs(), new SigningConfigurations(), mockPasswordHasher.Object);
            User user = new User
            {
                Email = "a@a.a",
                Password = "test",
                UserRoles = new List<UserRole> { new UserRole() { Role = new Role() { Name = "Common" } } }
            };

            //Act
            var result = tokenHandler.CreateAccessToken(user);

            //Assert
            var accessToken = Assert.IsAssignableFrom<AccessToken>(result);            
        }

        [Fact]
        public void TakeRefreshToken_ReturnsAccessTokenNull_WhenTokenIsNull()
        {
            //Arrange
            mockPasswordHasher = new Mock<IPasswordHasher>();
            TokenHandler tokenHandler = new TokenHandler(GetFakeConfigs(), new SigningConfigurations(), mockPasswordHasher.Object);

            //Act
            var result = tokenHandler.TakeRefreshToken(null);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void TakeRefreshToken_ReturnsAccessTokenNull_WhenTokenDoesnotExists()
        {
            //Arrange
            mockPasswordHasher = new Mock<IPasswordHasher>();
            TokenHandler tokenHandler = new TokenHandler(GetFakeConfigs(), new SigningConfigurations(), mockPasswordHasher.Object);

            //Act
            var result = tokenHandler.TakeRefreshToken("test");

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void TakeRefreshToken_ReturnsRefreshTokenAfterRemovingIt_WhenTokenExists()
        {
            //Arrange
            mockPasswordHasher = new Mock<IPasswordHasher>();
            mockPasswordHasher.Setup(s => s.HashPassword(It.IsAny<string>())).Returns("test");
            TokenHandler tokenHandler = new TokenHandler(GetFakeConfigs(), new SigningConfigurations(), mockPasswordHasher.Object);
            User user = new User
            {
                Email = "a@a.a",
                Password = "test",
                UserRoles = new List<UserRole> { new UserRole() { Role = new Role() { Name = "Common" } } }
            };
            var accessToken = tokenHandler.CreateAccessToken(user);

            //Act
            var result = tokenHandler.TakeRefreshToken("test");

            //Assert
            var refreshToken = Assert.IsAssignableFrom<RefreshToken>(result);
            Assert.NotNull(refreshToken);
            Assert.Equal(refreshToken, accessToken.RefreshToken);
        }

        private IOptions<AppConfigs> GetFakeConfigs()
        {
            return Options.Create<AppConfigs>(new AppConfigs
            {
                TokenOptions = new TokenOptions
                {
                    AccessTokenExpiration = 100,
                    Audience = "aud",
                    Issuer = "iss",
                    RefreshTokenExpiration = 200
                }
            });
        }
    }
}
