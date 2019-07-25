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
    public class UsersControllerTests : IClassFixture<CustomWebApplicationFactory<TestingStartup>>
    {
        public UsersControllerTests(CustomWebApplicationFactory<TestingStartup> factory) => Client = factory.CreateClient();

        private const string EMAIL = "a@a.a";
        private const string PASSWORD = "12345678";
        public HttpClient Client { get; }

        [Fact]
        public async Task CreateUserAsync_ShouldReturnOkResultWithCreatedUser()
        {
            UserCredentialsResource userCredentialsResource = GetUserToSave();
            var response = await Client.PostAsJsonAsync("/api/users/create-user", userCredentialsResource);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var savedUser = JsonConvert.DeserializeObject<UserResource>(stringResponse);
            Assert.True(savedUser.Id > 0);
            Assert.Equal(EMAIL, savedUser.Email);
            Assert.Single(savedUser.Roles);
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
