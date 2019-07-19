using System;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using ClientApp;
using Newtonsoft.Json;
using ClientApp.Controllers.Resources;
using System.Collections.Generic;
using ClientApp.Controllers.Resources.Security;

namespace FunctionalTests
{
    public class AuthControllerTests : IClassFixture<CustomWebApplicationFactory<TestingStartup>>
    {
        public AuthControllerTests(CustomWebApplicationFactory<TestingStartup> factory)
        {
            Client = factory.CreateClient();
        }

        private const string EMAIL = "admin@admin.com";
        private const string PASSWORD = "12345678";
        public HttpClient Client { get; }

        [Fact]
        public async Task LoginAsync_ShouldReturnAccessToken()
        {
            UserCredentialsResource userCredentialsResource = GetUserToSave();
            var response = await Client.PostAsJsonAsync("/api/login", userCredentialsResource);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var accessToken = JsonConvert.DeserializeObject<AccessTokenResource>(stringResponse);
            Assert.NotNull(accessToken.AccessToken);
            Assert.True(accessToken.Expiration > DateTime.Now.Ticks);
        }

        [Fact]
        public async Task RefreshTokenAsync_ShouldReturnAccessToken()
        {
            UserCredentialsResource userCredentialsResource = GetUserToSave();
            var response = await Client.PostAsJsonAsync("/api/login", userCredentialsResource);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var accessToken = JsonConvert.DeserializeObject<AccessTokenResource>(stringResponse);

            var refreshTokenResource = new RefreshTokenResource
            {
                UserEmail = EMAIL,
                Token = accessToken.RefreshToken
            };
            response = await Client.PostAsJsonAsync("/api/token/refresh", refreshTokenResource);
            response.EnsureSuccessStatusCode();
            stringResponse = await response.Content.ReadAsStringAsync();
            accessToken = JsonConvert.DeserializeObject<AccessTokenResource>(stringResponse);
            Assert.NotNull(accessToken.AccessToken);
            Assert.True(accessToken.Expiration > DateTime.Now.Ticks);
        }

        [Fact]
        public async Task RevokeToken_ShouldReturnNoContent()
        {
            UserCredentialsResource userCredentialsResource = GetUserToSave();
            var response = await Client.PostAsJsonAsync("/api/login", userCredentialsResource);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var accessToken = JsonConvert.DeserializeObject<AccessTokenResource>(stringResponse);

            var revokeTokenResource = new RevokeTokenResource
            {
                Token = accessToken.RefreshToken
            };
            response = await Client.PostAsJsonAsync("/api/token/revoke", revokeTokenResource);
            response.EnsureSuccessStatusCode();
        }

        private UserCredentialsResource GetUserToSave()
        {
            return new UserCredentialsResource()
            {
                Email = EMAIL,
                Password = PASSWORD
            };
        }
    }
}
