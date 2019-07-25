using System;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using ClientApp;
using Newtonsoft.Json;
using ClientApp.Controllers.Resources;
using System.Collections.Generic;

namespace FunctionalTests
{
    public class NidDocControllerTests : IClassFixture<CustomWebApplicationFactory<TestingStartup>>
    {
        public NidDocControllerTests(CustomWebApplicationFactory<TestingStartup> factory) => Client = factory.CreateClient();

        private const decimal DocPrice = 155;

        public HttpClient Client { get; }

        [Fact]
        public async Task GetDocPriceAsync_ReturnsCorrectPrice()
        {
            var response = await Client.GetAsync("/api/niddoc/doc-price");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var price = JsonConvert.DeserializeObject<decimal>(stringResponse);
            Assert.Equal(DocPrice, price);
        }

        [Fact]
        public async Task CreateNidDocAsync_ShouldReturnOkResultWithCreatedDocs()
        {
            NidDocResourceIn doc = GetDocToSave();
            var response = await Client.PostAsJsonAsync("/api/niddoc/create-nid-doc", doc);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var savedDoc = JsonConvert.DeserializeObject<NidDocResourceOut>(stringResponse);
            Assert.Equal(DocPrice, savedDoc.Price);
        }

        private NidDocResourceIn GetDocToSave()
        {
            return new NidDocResourceIn()
            {
                Name = new RequesterNameResource
                {
                    FirstName = "first",
                    FatherName = "father",
                    GrandFatherName = "grand",
                    FamilyName = "family"
                },
                JobName = "Engineer",
                JobTypeNIDId = 1,
                NidIssueReasonId = 1
            };
        }
    }
}
