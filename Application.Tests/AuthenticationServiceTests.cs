using System.Linq;
using Xunit;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Logging;
using Application.Interfaces;
using Application.Services;
using Domain.Entities.Lookups;
using Domain.Entities.Documents;
using System.Collections.Generic;
using Domain.Exceptions;
using Application.Services.Communication;
using Domain;
using Application.Security.Hashing;
using Application.Security.Services;
using Application.Security.Tokens;
using Domain.Entities.Security;
using System;
using Application.Security.Services.Communication;

namespace Application.Tests
{
    public class AuthenticationServiceTests
    {
        Mock<IUserService> mockUserService;
        Mock<IPasswordHasher> mockPasswordHasher;
        Mock<ITokenHandler> mockTokenHandler;

        [Fact]
        public async Task CreateAccessTokenAsync_ReturnsFailedTokenResponse_WhenUserNotExisting()
        {
            //Arrange
            CreateMockedObjects();
            mockUserService.Setup(a => a.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync((User)null);
            AuthenticationService authenticationService = new AuthenticationService(mockUserService.Object, mockPasswordHasher.Object, mockTokenHandler.Object);

            //Act
            var result = await authenticationService.CreateAccessTokenAsync("test", "test");

            //Assert
            Assert.IsAssignableFrom<TokenResponse>(result);
            Assert.False(result.Success);
            Assert.Null(result.Token);
        }

        [Fact]
        public async Task CreateAccessTokenAsync_ReturnsFailedTokenResponse_WhenPasswordNotMatching()
        {
            //Arrange
            CreateMockedObjects();
            mockUserService.Setup(a => a.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(new User());
            mockPasswordHasher.Setup(a => a.PasswordMatches(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            AuthenticationService authenticationService = new AuthenticationService(mockUserService.Object, mockPasswordHasher.Object, mockTokenHandler.Object);

            //Act
            var result = await authenticationService.CreateAccessTokenAsync("test", "test");

            //Assert
            Assert.IsAssignableFrom<TokenResponse>(result);
            Assert.False(result.Success);
            Assert.Null(result.Token);
        }

        [Fact]
        public async Task CreateAccessTokenAsync_ReturnsSucceededTokenResponse_WhenTokenCreatedSuccessfully()
        {
            //Arrange
            CreateMockedObjects();
            mockUserService.Setup(s => s.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(new User());
            mockPasswordHasher.Setup(s => s.PasswordMatches(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            mockTokenHandler.Setup(s => s.CreateAccessToken(It.IsAny<User>())).Returns(new AccessToken("token", 100, new RefreshToken("token", 100)));
            AuthenticationService authenticationService = new AuthenticationService(mockUserService.Object, mockPasswordHasher.Object, mockTokenHandler.Object);

            //Act
            var result = await authenticationService.CreateAccessTokenAsync("test", "test");

            //Assert
            var tokenResponse = Assert.IsAssignableFrom<TokenResponse>(result);
            Assert.True(result.Success);
            var accessToken = Assert.IsAssignableFrom<AccessToken>(tokenResponse.Token);
            Assert.Equal("token", accessToken.Token);
            Assert.Equal(100, accessToken.Expiration);
        }

        [Fact]
        public async Task RefreshTokenAsync_ReturnsFailedTokenResponse_WhenRefreshTokenIsNotExisting()
        {
            //Arrange
            CreateMockedObjects();
            mockTokenHandler.Setup(s => s.TakeRefreshToken(It.IsAny<string>())).Returns((RefreshToken)null);
            AuthenticationService authenticationService = new AuthenticationService(mockUserService.Object, mockPasswordHasher.Object, mockTokenHandler.Object);

            //Act
            var result = await authenticationService.RefreshTokenAsync("test", "test");

            //Assert
            var tokenResponse = Assert.IsAssignableFrom<TokenResponse>(result);
            Assert.False(result.Success);
            Assert.Null(result.Token);
        }

        [Fact]
        public async Task RefreshTokenAsync_ReturnsFailedTokenResponse_WhenTokenIsExpired()
        {
            //Arrange
            CreateMockedObjects();
            mockTokenHandler.Setup(s => s.TakeRefreshToken(It.IsAny<string>())).Returns(new RefreshToken("token", 100));
            AuthenticationService authenticationService = new AuthenticationService(mockUserService.Object, mockPasswordHasher.Object, mockTokenHandler.Object);

            //Act
            var result = await authenticationService.RefreshTokenAsync("test", "test");

            //Assert
            var tokenResponse = Assert.IsAssignableFrom<TokenResponse>(result);
            Assert.False(result.Success);
            Assert.Null(result.Token);
        }

        [Fact]
        public async Task RefreshTokenAsync_ReturnsFailedTokenResponse_WhenUserNotExisting()
        {
            //Arrange
            CreateMockedObjects();
            mockTokenHandler.Setup(s => s.TakeRefreshToken(It.IsAny<string>())).Returns(new RefreshToken("token", DateTime.Now.AddSeconds(100).Ticks));
            mockUserService.Setup(a => a.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync((User)null);
            AuthenticationService authenticationService = new AuthenticationService(mockUserService.Object, mockPasswordHasher.Object, mockTokenHandler.Object);

            //Act
            var result = await authenticationService.RefreshTokenAsync("test", "test");

            //Assert
            var tokenResponse = Assert.IsAssignableFrom<TokenResponse>(result);
            Assert.False(result.Success);
            Assert.Null(result.Token);
        }

        [Fact]
        public async Task RefreshTokenAsync_ReturnsSucceededTokenResponse_WhenCreatedTheRefreshedToken()
        {
            //Arrange
            CreateMockedObjects();
            mockTokenHandler.Setup(s => s.TakeRefreshToken(It.IsAny<string>())).Returns(new RefreshToken("token", DateTime.Now.AddSeconds(100).Ticks));
            mockUserService.Setup(a => a.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(new User());
            mockTokenHandler.Setup(s => s.CreateAccessToken(It.IsAny<User>())).Returns(new AccessToken("token", 100, new RefreshToken("token", 100)));
            AuthenticationService authenticationService = new AuthenticationService(mockUserService.Object, mockPasswordHasher.Object, mockTokenHandler.Object);

            //Act
            var result = await authenticationService.RefreshTokenAsync("test", "test");

            //Assert
            var tokenResponse = Assert.IsAssignableFrom<TokenResponse>(result);
            Assert.True(result.Success);
            var accessToken = Assert.IsAssignableFrom<AccessToken>(tokenResponse.Token);
            Assert.Equal("token", accessToken.Token);
            Assert.Equal(100, accessToken.Expiration);
        }

        private void CreateMockedObjects()
        {
            mockUserService = new Mock<IUserService>();
            mockPasswordHasher = new Mock<IPasswordHasher>();
            mockTokenHandler = new Mock<ITokenHandler>();
        }
    }
}
