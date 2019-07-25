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
    public class DeathDocControllerTests : IClassFixture<CustomWebApplicationFactory<TestingStartup>>
    {
        public DeathDocControllerTests(CustomWebApplicationFactory<TestingStartup> factory) => Client = factory.CreateClient();

        private const decimal DocPrice = 54;

        public HttpClient Client { get; }

        [Fact]
        public async Task GetDocPriceAsync_ReturnsCorrectPrice()
        {
            var response = await Client.GetAsync("/api/deathdoc/doc-price");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var price = JsonConvert.DeserializeObject<decimal>(stringResponse);
            Assert.Equal(DocPrice, price);
        }

        [Fact]
        public async Task CreateDeathDocsAsync_ShouldReturnOkResultWithCreatedDocs()
        {
            List<DeathDocResourceIn> docs = GetDocsToSave();
            var response = await Client.PostAsJsonAsync("/api/deathdoc/create-death-docs", docs);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var savedDocs = JsonConvert.DeserializeObject<IEnumerable<DeathDocResourceOut>>(stringResponse);
            Assert.Single(savedDocs);
        }

        private List<DeathDocResourceIn> GetDocsToSave()
        {
            return new List<DeathDocResourceIn>
            {
                new DeathDocResourceIn()
                {
                    Name = new RequesterNameResource
                    {
                        FirstName = "first", FatherName="father", GrandFatherName="grand", FamilyName="family"
                    },
                    MotherFullName = "Fatema",
                    NumberOfCopies = 3,
                    NID = new NIDResource{NationalIdenNumber="28410071402991" },
                    GenderId = 1,
                    RelationId = 2
                }
            };
        }
    }
}
