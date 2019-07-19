using Xunit;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Application.Configs;
using ClientApp.VerificationPlatform;
using Microsoft.Extensions.DependencyInjection;
using Domain.VerificationPlatform;

namespace ClientApp.Tests
{
    public class TokenVerificationTests
    {
        ILoggerFactory loggerFactory;

        [Fact]
        public void ValidateLogin_ReturnsNull_WhenEmailOrTokenIsEmpty()
        {
            // Arrange
            CreateMockedObjects();
            var tokenVerificarionService = new TokenVerificationService(GetFakeConfigs(), loggerFactory);

            //Act
            var result = tokenVerificarionService.ValidateLogin(null, null);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void ValidateLogin_ReturnsTestVerificationModel_WhenBypassVerificationApiFlagIsTrue()
        {
            // Arrange
            CreateMockedObjects();
            var tokenVerificarionService = new TokenVerificationService(GetFakeConfigs(), loggerFactory);

            //Act
            var result = tokenVerificarionService.ValidateLogin("test", "test");

            //Assert
            var verificationModel = Assert.IsAssignableFrom<VerificationModel>(result);
            Assert.Equal("1", verificationModel.Status);
        }

        [Fact]
        public void ValidateLogin_ReturnsNull_WhenBypassVerificationApiFlagIsFalseAndTheCredentialsAreNotValid()
        {
            // Arrange
            CreateMockedObjects();
            var tokenVerificarionService = new TokenVerificationService(GetFakeConfigs_NoByPassVerificationApi(), loggerFactory);

            //Act
            var result = tokenVerificarionService.ValidateLogin("test", "test");

            //Assert
            Assert.Null(result);
        }

        private IOptions<AppConfigs> GetFakeConfigs()
        {
            return Options.Create<AppConfigs>(new AppConfigs
            {
                VerificationPlatformOptions=new VerificationPlatformOptions
                {
                    BypassVerificationApi = true
                }
            });
        }

        private IOptions<AppConfigs> GetFakeConfigs_NoByPassVerificationApi()
        {
            return Options.Create<AppConfigs>(new AppConfigs
            {
                VerificationPlatformOptions = new VerificationPlatformOptions
                {
                    BypassVerificationApi = false,
                    ApiGetAccessTokenUrl = "https://webapi.moi.gov.eg//token",
                    ApiLoginUrl = "https://moi.gov.eg/Account/Login",
                    ApiPassword = "Xwouifkh@moi978",
                    ApiUserName = "traffic@moi.com",
                    ApiValidateLoginUrl = "https://webapi.moi.gov.eg//api//moiMemberApi//ValidateLogin"
                }
            });
        }

        private void CreateMockedObjects()
        {
            loggerFactory = CreateLogger();
        }

        private ILoggerFactory CreateLogger()
        {
            //var mockLogger = new Mock<ILoggerFactory>();
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();
            var logFactory = serviceProvider.GetService<ILoggerFactory>();
            return logFactory;
        }
    }
}
