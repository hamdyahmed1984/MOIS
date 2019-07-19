using Xunit;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ClientApp.Controllers;
using ClientApp.Mapping;
using Application.Security.Services;
using Application.Security.Services.Communication;
using ClientApp.Controllers.Resources.Security;
using System;

namespace ClientApp.Tests
{
    public class AuthControllerTests
    {
        IMapper mapper;
        Mock<IAuthenticationService> mockAuthService;

        [Fact]
        public async Task LoginAsync_ReturnsBadRequest_WhenFailedToCreateAccessToken()
        {
            //Arrange  
            CreateMockedObjects();
            mockAuthService.Setup(s => s.CreateAccessTokenAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(GetFakeFailedTokenResponse());
            var controller = new AuthController(mapper, mockAuthService.Object);

            //Act
            var result = await controller.LoginAsync(GetFakeUserCredentialsResource());

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("failed to create access token!", badRequestResult.Value);
        }

        [Fact]
        public async Task LoginAsync_ReturnsOkWithAccessTokenResource_WhenSucceededToCreateAccessToken()
        {
            //Arrange  
            CreateMockedObjects();
            mockAuthService.Setup(s => s.CreateAccessTokenAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(GetFakeSucceededTokenResponse());
            var controller = new AuthController(mapper, mockAuthService.Object);

            //Act
            var result = await controller.LoginAsync(GetFakeUserCredentialsResource());

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var accessTokenResource = Assert.IsAssignableFrom<AccessTokenResource>(okResult.Value);
            Assert.Equal("token", accessTokenResource.AccessToken);
            Assert.Equal(100, accessTokenResource.Expiration);
        }

        [Fact]
        public async Task RefreshTokenAsync_ReturnsBadRequest_WhenFailedToRefereshToken()
        {
            //Arrange  
            CreateMockedObjects();
            mockAuthService.Setup(s => s.RefreshTokenAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(GetFakeFailedTokenResponse());
            var controller = new AuthController(mapper, mockAuthService.Object);

            //Act
            var result = await controller.RefreshTokenAsync(GetFakeRefreshTokenResource());

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("failed to create access token!", badRequestResult.Value);
        }

        [Fact]
        public async Task RefreshTokenAsync_ReturnsOkWithAccessTokenResource_WhenSucceededToRefreshToken()
        {
            //Arrange  
            CreateMockedObjects();
            mockAuthService.Setup(s => s.RefreshTokenAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(GetFakeSucceededTokenResponse());
            var controller = new AuthController(mapper, mockAuthService.Object);

            //Act
            var result = await controller.RefreshTokenAsync(GetFakeRefreshTokenResource());

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var accessTokenResource = Assert.IsAssignableFrom<AccessTokenResource>(okResult.Value);
            Assert.Equal("token", accessTokenResource.AccessToken);
            Assert.Equal(100, accessTokenResource.Expiration);
        }

        [Fact]
        public void RevokeToken_ReturnsNoContent_WhenSucceededToRevokeToken()
        {
            //Arrange  
            CreateMockedObjects();
            mockAuthService.Setup(s => s.RevokeRefreshToken(It.IsAny<string>()));
            var controller = new AuthController(mapper, mockAuthService.Object);

            //Act
            var result = controller.RevokeToken(GetFakeRevokeTokenResource());

            //Assert
            var okResult = Assert.IsType<NoContentResult>(result);
        }

        private RevokeTokenResource GetFakeRevokeTokenResource()
        {
            return new RevokeTokenResource { Token = "token" };
        }

        private UserCredentialsResource GetFakeUserCredentialsResource()
        {
            return new UserCredentialsResource
            {
                Email = "test",
                Password = "test"
            };
        }

        private TokenResponse GetFakeFailedTokenResponse()
        {
            return new TokenResponse(false, "failed to create access token!", null);
        }

        private TokenResponse GetFakeSucceededTokenResponse()
        {
            return new TokenResponse(true, "!",
                new Application.Security.Tokens.AccessToken("token", 100, new Application.Security.Tokens.RefreshToken("token", 100)));
        }

        private void CreateMockedObjects()
        {
            mapper = CreateMapper();
            mockAuthService = new Mock<IAuthenticationService>();
        }

        private RefreshTokenResource GetFakeRefreshTokenResource()
        {
            return new RefreshTokenResource
            {
                UserEmail = "test",
                Token = " test"
            };
        }


        private IMapper CreateMapper()
        {
            //var mockIMapper = new Mock<IMapper>();
            var config = new MapperConfiguration(opts =>
            {
                // Add your mapper profile configs or mappings here
                opts.AddProfile<ModelToResourceProfile>();
                opts.AddProfile<ResourceToModelProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
